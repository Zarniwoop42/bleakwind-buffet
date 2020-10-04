/*
 * Author: Zachery Brunner
 * Class: SmokehouseSkeletonTests.cs
 * Purpose: Test the SmokehouseSkeleton.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class SmokehouseSkeletonTests
    {
        [Fact]
        public void ChangingSausageLinkNotifiesSausageLinkProperty()
        {
            var shs = new SmokehouseSkeleton();

            Assert.PropertyChanged(shs, "SausageLink", () =>
            {
                shs.SausageLink = true;
            });

            Assert.PropertyChanged(shs, "SausageLink", () =>
            {
                shs.SausageLink = false;
            });
        }
        [Fact]
        public void ChangingEggNotifiesEggProperty()
        {
            var shs = new SmokehouseSkeleton();

            Assert.PropertyChanged(shs, "Egg", () =>
            {
                shs.Egg = true;
            });

            Assert.PropertyChanged(shs, "Egg", () =>
            {
                shs.Egg = false;
            });
        }
        [Fact]
        public void ChangingHashBrownsNotifiesHashBrownsProperty()
        {
            var shs = new SmokehouseSkeleton();

            Assert.PropertyChanged(shs, "HashBrowns", () =>
            {
                shs.HashBrowns = true;
            });

            Assert.PropertyChanged(shs, "HashBrowns", () =>
            {
                shs.HashBrowns = false;
            });
        }
        [Fact]
        public void ChangingPancakeNotifiesPancakeProperty()
        {
            var shs = new SmokehouseSkeleton();

            Assert.PropertyChanged(shs, "Pancake", () =>
            {
                shs.Pancake = true;
            });

            Assert.PropertyChanged(shs, "Pancake", () =>
            {
                shs.Pancake = false;
            });
        }

        [Fact]
        public void ShouldBeAnIOrderItem()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            Assert.IsAssignableFrom<IOrderItem>(shs);
        }
        [Fact]
        public void ShouldBeAnEntree()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            Assert.IsAssignableFrom<Entree>(shs);
        }

        [Fact]
        public void ShouldInlcudeSausageLinkByDefault()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            Assert.True(shs.SausageLink);
        }

        [Fact]
        public void ShouldInlcudeEggByDefault()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            Assert.True(shs.Egg);
        }

        [Fact]
        public void ShouldInlcudeHashBrownsByDefault()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            Assert.True(shs.HashBrowns);
        }

        [Fact]
        public void ShouldInlcudePancakeByDefault()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            Assert.True(shs.Pancake);
        }

        [Fact]
        public void ShouldBeAbleToSetSausageLink()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            shs.SausageLink = true;
            Assert.True(shs.SausageLink);
            shs.SausageLink = false;
            Assert.False(shs.SausageLink);
        }

        [Fact]
        public void ShouldBeAbleToSetEgg()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            shs.Egg = true;
            Assert.True(shs.Egg);
            shs.Egg = false;
            Assert.False(shs.Egg);
        }

        [Fact]
        public void ShouldBeAbleToSetHashBrowns()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            shs.HashBrowns = true;
            Assert.True(shs.HashBrowns);
            shs.HashBrowns = false;
            Assert.False(shs.HashBrowns);
        }

        [Fact]
        public void ShouldBeAbleToSetPancake()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            shs.Pancake = true;
            Assert.True(shs.Pancake);
            shs.Pancake = false;
            Assert.False(shs.Pancake);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            Assert.Equal(5.62, shs.Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            Assert.Equal((double)602, shs.Calories);
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeSausage, bool includeEgg,
                                                            bool includeHashbrowns, bool includePancake)
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            shs.SausageLink = includeSausage; shs.Egg = includeEgg; shs.HashBrowns = includeHashbrowns; shs.Pancake = includePancake;
            if (!includeSausage) Assert.Contains("Hold sausage", shs.SpecialInstructions);
            if (!includeEgg) Assert.Contains("Hold eggs", shs.SpecialInstructions);
            if (!includeHashbrowns) Assert.Contains("Hold hash browns", shs.SpecialInstructions);
            if (!includePancake) Assert.Contains("Hold pancakes", shs.SpecialInstructions);
            if (includeSausage && includeEgg && includeHashbrowns && includePancake) Assert.Empty(shs.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            SmokehouseSkeleton shs = new SmokehouseSkeleton();
            Assert.Equal("Smokehouse Skeleton", shs.ToString());
        }
    }
}