﻿/*
 * Author: Zachery Brunner
 * Class: ThugsTBoneTests.cs
 * Purpose: Test the ThugsTBone.cs class in the Data library
 */
using Xunit;
using System.ComponentModel;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class ThugsTBoneTests
    {
        [Fact]
        public void ShouldBeAnIOrderItem()
        {
            ThugsTBone ttb = new ThugsTBone();
            Assert.IsAssignableFrom<IOrderItem>(ttb);
        }
        [Fact]
        public void ShouldBePropertyChanged()
        {
            ThugsTBone ttb = new ThugsTBone();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ttb);
        }
        [Fact]
        public void ShouldBeAnEntree()
        {
            ThugsTBone ttb = new ThugsTBone();
            Assert.IsAssignableFrom<Entree>(ttb);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            ThugsTBone ttb = new ThugsTBone();
            Assert.Equal(6.44, ttb.Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            ThugsTBone ttb = new ThugsTBone();
            Assert.Equal((double)982, ttb.Calories);
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            ThugsTBone ttb = new ThugsTBone();
            Assert.Empty(ttb.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            ThugsTBone ttb = new ThugsTBone();
            Assert.Equal("Thugs T-Bone", ttb.ToString());
        }
    }
}