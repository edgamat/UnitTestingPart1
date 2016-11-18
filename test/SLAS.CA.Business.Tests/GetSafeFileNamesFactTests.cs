using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SLAS.CA.Business.Tests
{
    public class GetSafeFileNamesFactTests
    {
        [Fact]
        public void BasicUsage()
        {
            // Arrange
            var fileName = "REPORT_USER_ACTIVITY_2016/11/17 12:00PM.PDF";

            // Act
            var safeName = FileHelper.GetSafeFileName(fileName);

            // Assert
            Assert.Equal("REPORT_USER_ACTIVITY_2016_11_17 12_00PM.PDF", safeName);
        }

        [Fact]
        public void GivenEmptyString_ReturnEmptyString()
        {
            // Arrange
            var fileName = "";

            // Act
            var safeName = FileHelper.GetSafeFileName(fileName);

            // Assert
            Assert.Equal("", safeName);
        }

        [Fact]
        public void GivenNull_RaiseException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Arrange
                var fileName = (string)null;

                // Act
                var safeName = FileHelper.GetSafeFileName(fileName);
            });
        }

        [Fact]
        public void GivenTagInName_ReturnsSafeName()
        {
            // Arrange
            var fileName = "REPORT\tUSER.pdf";

            // Act
            var safeName = FileHelper.GetSafeFileName(fileName);

            // Assert
            Assert.Equal("REPORT_USER.pdf", safeName);
        }
    }
}
