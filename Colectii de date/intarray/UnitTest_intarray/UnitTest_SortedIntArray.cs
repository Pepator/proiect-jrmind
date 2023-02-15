using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectiiDeDate
{
    public class UnitTest_SortedIntArray
    {
        [Fact]
        public void Add_TestSortedAddMethod_ShouldReturnRightNumberOfElementsInOrder()
        {
            var testArray = new SortedIntArray();
            testArray.Add(10);
            testArray.Add(2);
            testArray.Add(3);

            Assert.Equal(3, testArray.Count);
            Assert.Equal(10, testArray[2]);
        }

        [Fact]
        public void Count_TestSortedCountMethod_ShouldReturnRightNumberOfElements()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(2, testArray.Count);
        }

        [Fact]
        public void Element_TestSortedElementMethod_ShouldReturnCorrectElement()
        {
            var testArray = new SortedIntArray();
            testArray.Add(2);
            testArray.Add(1);

            Assert.Equal(1, testArray[0]);
        }

        [Fact]
        public void SetElement_TestSortedSetElementMethod_ShouldReturnCorrectElement()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray.Add(3);
            testArray[0] = 4;

            Assert.Equal(4, testArray[1]);
        }

        [Fact]
        public void Contains_TestSortedContainsMethod_ShouldRetrunTrueIfElementIsFound()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray[0] = 100;

            Assert.True(testArray.Contains(100));
            Assert.False(testArray.Contains(10));
        }

        [Fact]
        public void IndeOf_TestSortedIndexOfMethod_ShouldReturnIndexOfElement()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray[0] = 100;

            Assert.Equal(0, testArray.IndexOf(100));
            Assert.Equal(-1, testArray.IndexOf(10));
        }

        [Fact]
        public void Insert_TestSortedInsertMethod_ShouldreturnNewSizeAndCorrectElementInCorrectIndex()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(4);
            testArray.Insert(1, 3);

            Assert.Equal(4, testArray.Count);
            Assert.Equal(3, testArray[2]);
        }

        [Fact]
        public void Clear_TestSortedClearMethod_ShouldRemoveAllElements()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Clear();

            Assert.Equal(0, testArray.Count);
        }

        [Fact]
        public void Remove_TestSortedRemoveMethod_ShouldRemoveCorrectElement()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray.Add(3);
            testArray.Remove(1);

            Assert.Equal(1, testArray.Count);
            Assert.Equal(3, testArray[0]);
        }

        [Fact]
        public void RemoveAt_TestSortedRemoveAtMethod_ShouldRemoveElementAtCorrectIndex()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray.Add(3);
            testArray.RemoveAt(1);

            Assert.Equal(1, testArray.Count);
            Assert.Equal(1, testArray[0]);
        }

    }
}
