using BusinessBears.Library;
using System;
using System.Collections.Generic;
using Xunit;

namespace BusinessBears.Tests
{
    public class BearTest
    {
        private readonly Bear testbear = new Bear();
        [Fact]
        public void BearCanTakeUpgrades()
        {
            
            Training t2 = new Training("Walnut Crushing", 27.99);
            testbear.AddTraining(t2);

            //assert
            Assert.Contains(t2, testbear.upgrades);

        }

        [Fact]
        public void BearUpgradesOnlyTakesTrainingObjects()
        {
           




        }
    }
}