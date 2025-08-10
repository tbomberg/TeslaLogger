﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaLogger;

namespace UnitTestsTeslalogger
{
    [TestClass]
    public class UnitTestOSMMapGenerator
    {
        [TestInitialize]
        public void InitializeTests()
        {
            if (!Directory.Exists("maps"))
                Directory.CreateDirectory("maps");

            if (!Directory.Exists("map-data"))
                Directory.CreateDirectory("map-data");
        }

        [TestMethod]
        public void ParkingP1()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            var f = new FileInfo("../../../Testfile-P1.txt");
            string tempfile = GetTempFileName();
            f.CopyTo(tempfile, true);

            var map = new FileInfo("maps/P-51,1624-13,5748.png");
            if (map.Exists)
                map.Delete();

            string p = f.FullName;

            string[] args = { "-jobfile", tempfile, "-debug" };
            OSMMapGenerator.Main(args);

            System.Diagnostics.Debug.Write(sw.ToString());
            map = new FileInfo("maps/P-51,1624-13,5748.png");
            Assert.IsTrue(map.Exists);
            sw.Dispose();
        }

        [TestMethod]
        public void ParkingP2()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            var f = new FileInfo("../../../Testfile-P2.txt");
            string tempfile = GetTempFileName();
            f.CopyTo(tempfile, true);

            var map = new FileInfo("maps/P-51,1576-13,6364.png");
            if (map.Exists)
                map.Delete();

            string p = f.FullName;

            string[] args = { "-jobfile", tempfile, "-debug" };
            OSMMapGenerator.Main(args);
            System.Diagnostics.Debug.Write(sw.ToString());
            map = new FileInfo("maps/P-51,1576-13,6364.png");
            Assert.IsTrue(map.Exists);
            sw.Dispose();
        }

        [TestMethod]
        public void ParkingP3()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            var f = new FileInfo("../../../Testfile-P3.txt");
            string tempfile = GetTempFileName();
            f.CopyTo(tempfile, true);

            var map = new FileInfo("maps/P-51,2576-13,7364.png");
            if (map.Exists)
                map.Delete();

            string p = f.FullName;

            string[] args = { "-jobfile", tempfile, "-debug" };
            OSMMapGenerator.Main(args);
            System.Diagnostics.Debug.Write(sw.ToString());

            map = new FileInfo("maps/P-51,2576-13,7364.png");
            Assert.IsTrue(map.Exists);
            sw.Dispose();
        }

        [TestMethod]
        public void ParkingP4()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            var f = new FileInfo("../../../Testfile-P4.txt");
            string tempfile = GetTempFileName();
            f.CopyTo(tempfile, true);

            var map = new FileInfo("maps/P-51,1576-13,6364.png");
            if (map.Exists)
                map.Delete();

            string p = f.FullName;

            string[] args = { "-jobfile", tempfile, "-debug" };
            OSMMapGenerator.Main(args);
            System.Diagnostics.Debug.Write(sw.ToString());

            map = new FileInfo("maps/P-51,1576-13,6364.png");
            Assert.IsTrue(map.Exists);
            sw.Dispose();
        }

        [TestMethod]
        public void ChargingC1()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            var f = new FileInfo("../../../Testfile-C1.txt");
            string tempfile = GetTempFileName();
            f.CopyTo(tempfile, true);

            var map = new FileInfo("maps/C-51,1624-13,5748.png");
            if (map.Exists)
                map.Delete();

            string p = f.FullName;

            string[] args = { "-jobfile", tempfile, "-debug" };
            OSMMapGenerator.Main(args);

            System.Diagnostics.Debug.Write(sw.ToString());
            map = new FileInfo("maps/C-51,1624-13,5748.png");
            Assert.IsTrue(map.Exists);
            sw.Dispose();
        }

        [TestMethod]
        public void TripT1()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            var f = new FileInfo("../../../Testfile-T1.txt");
            string tempfile = GetTempFileName();
            f.CopyTo(tempfile, true);

            var map = new FileInfo("maps/T2-400371-400398.png");
            if (map.Exists)
                map.Delete();

            string p = f.FullName;

            string[] args = { "-jobfile", tempfile, "-debug" };
            OSMMapGenerator.Main(args);
            
            map = new FileInfo("maps/T2-400371-400398.png");
            Assert.IsTrue(map.Exists);
            Console.WriteLine("Pfad: " + map.FullName);

            System.Diagnostics.Debug.Write(sw.ToString());
            sw.Dispose();
        }

        static string GetTempFileName()
        {
            return Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        }
    }
}
