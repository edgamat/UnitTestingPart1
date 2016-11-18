using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace SLAS.CA.Business.Tests
{
    public class GetSafeFileNameTests
    {
        private ITestOutputHelper output;

        public GetSafeFileNameTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public static IEnumerable<object[]> SampleData()
        {
            var list = new List<object[]>();

            list.Add(new[] { "", "" });
            list.Add(new[] { "REPORT\tNAME.PDF", "REPORT_NAME.PDF" });
            list.Add(new[] { "REPORT\bNAME.PDF", "REPORT_NAME.PDF" });
            list.Add(new[] { "REPORT_USER_ACTIVITY_2016/11/12 10:00AM.PDF", "REPORT_USER_ACTIVITY_2016_11_12 10_00AM.PDF" });

            return list;
        }

        [Theory]
        [MemberData("SampleData")]
        public void BasicUsage(string fileName, string expectedSafeName)
        {
            // Act
            var actualSafeName = FileHelper.GetSafeFileName(fileName);

            // Assert
            Assert.Equal(expectedSafeName, actualSafeName);
        }

        [Fact]
        public void GivenNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var fileName = (string)null;

                var safeName = FileHelper.GetSafeFileName(fileName);
            });
        }

        [Fact(Skip = "Debugging method I don't know much about.")]
        public void Debugging_GetInvalidCharList()
        {
            var invalidChars = System.IO.Path.GetInvalidFileNameChars();

            foreach (var item in invalidChars)
            {
                this.output.WriteLine("{0}", (byte)item);
            }
        }
    }
}
