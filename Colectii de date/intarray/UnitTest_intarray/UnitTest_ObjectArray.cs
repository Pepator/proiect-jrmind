using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class UnitTest_ObjectArray
    {
        [Fact]
        public void Add_TestObjectArrayClass_ShouldReturnRightNumberOfElementsInOrder()
        {
            var testArray = new ObjectArray();
            testArray.Add(1);
            testArray.Add("asd");
            testArray.Add(true);
            testArray.Insert(0, "aa");

            Assert.Equal(4, testArray.Count);
            Assert.Equal("asd", testArray[2]);
        }
    }
}
