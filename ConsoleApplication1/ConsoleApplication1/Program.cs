using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Service
{
    public class Program
    {
        static void Main(string[] args)
        {
            DKcitizen dkC = new DKcitizen();
            dkC.cprNr = "251287-1234";
            dkC.firstName = "Anne Dyhr";
            dkC.surName = "Pedersen";

            EUcitizenCanonical euC = new EUcitizenCanonical();
            euC.euccid = "2512871234";
            euC.christianName = "Anne Dyhr";
            euC.familyName = "Pedersen";
            euC.gender = gender.Female;

            Service service = new Service();
            //TextWriter writer = new StreamWriter(@"C:\Users\Anne Dyhr\Desktop\citizen.xml");
            //service.getXmlSerializer().Serialize(writer, euC);
            MessageQueue dkIn = Service.generateMsgQueue("dkIn");
            MessageQueue dkOut = Service.generateMsgQueue("dkOut");
            MessageQueue transIn = Service.generateMsgQueue("translatorIn");
            MessageQueue euIn = Service.generateMsgQueue("euIn");
            MessageQueue euOut = Service.generateMsgQueue("euOut");

            Endpoint dk = new Endpoint(dkIn, transIn);
            DKtoEUtranslator trans = new DKtoEUtranslator(transIn, euIn);
            Endpoint eu = new Endpoint(euIn, dkIn);
            dkIn.Send(euC);
            dk.Process();
            Console.ReadLine();
        }
    }

    public class Service
    {
        //static fields are shared by all
        static protected readonly string queuePath = @".\private$\";
        static private MessageQueue deadletter;

        public Service()
        {
            deadletter = Service.generateMsgQueue("deadletter");
        }
        private XmlSerializer xmlSerializer;
        public XmlSerializer getXmlSerializer()
        {
            if (xmlSerializer == null)
            {
                xmlSerializer = new XmlSerializer(typeof(EUcitizenCanonical));
            }
            return xmlSerializer;
        }
        public static MessageQueue generateMsgQueue(string name)
        {
            string path = queuePath + name;

            // Create the Queue
            if (!MessageQueue.Exists(path))
            {
                MessageQueue.Create(path);
            }
            MessageQueue messageQueue = new MessageQueue(path);
            messageQueue.Label = name + " channel";

            return messageQueue;
        }
    }
    //Er det blot et interface for endpoints/gateways?
    public abstract class PointToPoint
    {
        //in channel, out channel
        protected MessageQueue inChannel;
        protected MessageQueue outChannel;
        protected string id;

        public PointToPoint(MessageQueue inChannel, MessageQueue outChannel, string id)
        {
            this.inChannel = inChannel;
            this.outChannel = outChannel;
            this.id = id;
        }
 
        public void Process()
        {
            inChannel.ReceiveCompleted += new ReceiveCompletedEventHandler(OnReceiveCompleted);
            inChannel.BeginReceive();
        }
        private void OnReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue channel = (MessageQueue)source;
            channel.Formatter = new XmlMessageFormatter(new Type[] { typeof(EUcitizenCanonical) });
            
            var inMsg = channel.EndReceive(asyncResult.AsyncResult);
            var body = (EUcitizenCanonical)inMsg.Body;
            Message outMsg = ProcessMessage(inMsg);
            outChannel.Send(outMsg);

            channel.BeginReceive();
        }

        //Here translation and so fort is done...
        protected virtual Message ProcessMessage(Message m)
        {
            Console.WriteLine("Received message");
            Console.WriteLine(m.Body);
            return m;
        }
    }

    public class DKtoEUtranslator : PointToPoint
    {
        public DKtoEUtranslator(MessageQueue inChannel, MessageQueue outChannel, string id) : base(inChannel, outChannel, id) {}
        protected override Message ProcessMessage(Message m)
        {
            //do translation!!
            return base.ProcessMessage(m);
        }
    }
    //Application->endpoint->messaging system
    public class Endpoint : PointToPoint
    {
        public Endpoint(MessageQueue inChannel, MessageQueue outChannel, string id) : base(inChannel, outChannel, id)
        { }   
    }
}
