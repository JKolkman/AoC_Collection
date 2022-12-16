
using System;
using System.Collections.Generic;
using AoC_Collection;
using NUnit.Framework;

namespace AoC_Tests;
public class TestsYear2015
{
    public static TestsYear2015 CreateInstance()
    {
        return new TestsYear2015();
    }

    public class Day01
    {
        private List<string> input;
        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 11);
        }
        
        [Test]
        public void Part_1()
        {
            Year2015.D1P1(input);
        }

        [Test]
        public void Part_2()
        {
            Year2015.D1P2(input);
        }
    }

    public class Day02
    {
        private List<string> input;
        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 2);
        }
        
        [Test]
        public void Part_1()
        {
            Year2015.D2P1(input);
        }

        [Test]
        public void Part_2()
        {
            Year2015.D2P2(input);
        }
    }

    public class Day03
    {
        private List<string> input;
        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 3);
        }
        
        [Test]
        public void Part_1()
        {
            Year2015.D3P1(input);
        }

        [Test]
        public void Part_2()
        {
            Year2015.D3P2(input);
        }
    }
    
    public class Day04
    {
        private List<string> input;
        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 4);
        }
        
        [Test]
        public void Part_1()
        {
            Year2015.D4P1(input);
        }

        [Test]
        public void Part_2()
        {
            Year2015.D4P2(input);
        }
    }
    
    public class Day05
    {
        private List<string> input;
        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 5);
        }
        
        [Test]
        public void Part_1()
        {
            Year2015.D5P1(input);
        }

        [Test]
        public void Part_2()
        {
            Year2015.D5P2(input);
        }
    }

    public class Day06
    {
        private List<string> input;

        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 6);
        }

        [Test]
        public void Part_1()
        {
            Year2015.D6P1(input);
        }

        [Test]
        public void Part_2()
        {
            Year2015.D6P2(input);
        }
    }
    
    public class Day07
    {
        private List<string> input;

        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 7);
        }

        [Test]
        public void Part_1()
        {
            Year2015.D7P1(input);
        }

        [Test]
        public void Part_2()
        {
            Year2015.D7P2(input);
        }
    }

    public class Day08
    {
        private List<string> input;

        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 8);
        }

        [Test]
        public void Part_1()
        {
            Year2015.D8P1(input);
        }
        
        [Test]
        public void Part_2()
        {
            Year2015.D8P2(input);
        }
    }
    
    public class Day09
    {
        private List<string> input;

        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 9);
        }

        [Test]
        public void Part_1()
        {
            Year2015.D9P1(input);
        }
        
        [Test]
        public void Part_2()
        {
            Year2015.D9P2(input);
        }
    }
    
    public class Day10
    {
        private List<string> input;

        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 10);
        }

        [Test]
        public void Part_1()
        {
            Year2015.D10P1(input);
        }
        
        [Test]
        public void Part_2()
        {
            Year2015.D10P2(input);
        }
    }
    
    public class Day11
    {
        private List<string> input;

        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 11);
        }

        [Test]
        public void Part_1()
        {
            Year2015.D11P1(input);
        }
        
        [Test]
        public void Part_2()
        {
            Year2015.D11P2(input);
        }
    }

    public class Day12
    {
        private List<string> input;

        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 12);
        }
        
        [Test]
        public void Part_1()
        {
            Year2015.D12P1(input);
        }
        
        [Test]
        public void Part_2()
        {
            Year2015.D12P2(input);
        }
    }
    
    public class Day13
    {
        private List<string> input;

        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 13);
        }
        
        [Test]
        public void Part_1()
        {
            Year2015.D13P1(input);
        }
        
        [Test]
        public void Part_2()
        {
            //Year2015.D13P2(input);
        }
    }
    
    public class Day14
    {
        private List<string> input;

        [Test]
        public void GetInput()
        {
            input = DataGatherer.GetDataAsList(2015, 14);
        }
        
        [Test]
        public void Part_1()
        {
            Year2015.D14(input);
        }
    }
}