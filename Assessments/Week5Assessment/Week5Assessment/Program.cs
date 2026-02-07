using System;
using System.Collections.Generic;
using System.IO;

namespace Week5Assessment
{
    class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string message) : base(message) { }
    }

    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message) : base(message) { }
    }

    interface ILoggable
    {
        void SaveLog(string message);
    }

    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool isFragile { get; set; }
        public bool isReinforced { get; set; }
        public abstract void ProcessShipment();
    }

    class ExpressShipment : Shipment
    {
        public override void ProcessShipment()
        {
            Console.WriteLine($"Processing Express Shipment: {TrackingId}");
        }
    }
    class HeavyFreight : Shipment
    {
        public override void ProcessShipment()
        {
            if (Weight > 1000)
                Console.WriteLine($"Heavy lift permit granted for {TrackingId}");

            else
                Console.WriteLine($"No heavy lift permit required for {TrackingId}");
        }
    }

    class LogManager : ILoggable
    {
        public void SaveLog(string message)
        {
            Console.WriteLine($"{message}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager log = new LogManager();
            List<Shipment> a = new List<Shipment>();
                a.Add(new ExpressShipment()
                {
                    TrackingId = "AB101",
                    Weight = 1000,
                    Destination = "Chicago",
                    isFragile = false,
                    isReinforced = false,
                });
                a.Add(new ExpressShipment()
                {
                    TrackingId = "AB102",
                    Weight = 800,
                    Destination = "NorthPole",
                    isFragile = true,
                    isReinforced = true,
                });
                a.Add(new ExpressShipment()
                {
                    TrackingId = "AB104",
                    Weight = 1200,
                    Destination = "UnknownIsland",
                    isFragile = true,
                    isReinforced = false,
                });
                a.Add(new HeavyFreight()
                {
                    TrackingId = "AB103",
                    Weight = 1100,
                    Destination = "NewYork",
                    isFragile = true,
                    isReinforced = false,
                });
                a.Add(new HeavyFreight()
                {
                    TrackingId = "AB105",
                    Weight = 1100,
                    Destination = "CHANDIGARH",
                    isFragile = false,
                    isReinforced = false,
                });
            foreach (var v in a)
            {
                v.ProcessShipment();
            }
            Console.WriteLine("-----------------------------------");
            string file = @"..\..\..\shipment_auditlog.txt";
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine("SHIPMENTS AUDIT LOG ");
                foreach (var sh in a)
                {
                    try
                    {
                        if (sh.Destination != "NorthPole" && sh.Destination != "UnknownIsland")
                        {
                            sw.WriteLine($"Valid Shipment : ShipmentId {sh.TrackingId} to {sh.Destination}");
                            log.SaveLog($"ShipmentId {sh.TrackingId} Valid Destination: {sh.Destination}");
                        }
                        else if (sh.Weight < 0 || (sh.isFragile && !sh.isReinforced))
                        {
                            sw.WriteLine($"Insecure Shipment : ShipmentId {sh.TrackingId} to {sh.Destination}");
                            log.SaveLog($"The package is not secure to be delivered. ShipmentId {sh.TrackingId}");
                            throw new InsecurePackagingException("Insecure Packaging Detected");
                        }
                        else
                        {
                            sw.WriteLine($"Invalid Shipment : ShipmentId {sh.TrackingId} to {sh.Destination}");
                            log.SaveLog($"Security Alert : ShipmentId {sh.TrackingId} Invalid Destination : {sh.Destination}");
                            throw new RestrictedDestinationException("Denied Location");
                        }
                    }
                    catch (RestrictedDestinationException e)
                    {
                        Console.WriteLine($"{e.Message}");
                    }
                    catch (InsecurePackagingException e)
                    {
                        Console.WriteLine($"{e.Message}");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Data Entry error");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message}");
                    }
                    finally
                    {
                        Console.WriteLine($"Processing attempt finished for ID : {sh.TrackingId}");
                        Console.WriteLine("-----------------------------------");
                    }
                }
            }
        }
    }
}
