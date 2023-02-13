namespace ColectiiDeDate
{
    public class UnitTest_IntArray
    {
        [Fact]
        public void Add_TestAddMethod_ShouldReturnRightNumberOfElementsInOrder()
        {
            int[] array = {1, 2, 3};
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);

            Assert.Equal(3, testArray.Count());
            Assert.Equal(2, testArray.Element(1));
        }

        [Fact]
        public void Count_TestCountMethod_ShouldReturnRightNumberOfElements()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(1);

            Assert.Equal(4, testArray.Count());
        }

        [Fact]
        public void Element_TestElementMethod_ShouldReturnCorrectElement()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(1);

            Assert.Equal(3, testArray.Element(2));
        }

        [Fact]
        public void SetElement_TestSetElementMethod_ShouldReturnCorrectElement()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.SetElement(1, 100);

            Assert.Equal(100, testArray.Element(1));
        }

        [Fact]
        public void Contains_TestContainsMethod_ShouldRetrunTrueIfElementIsFound()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.SetElement(1, 100);

            Assert.True(testArray.Contains(100));
            Assert.False(testArray.Contains(10));
        }

        [Fact]
        public void IndeOf_TestIndexOfMethod_ShouldReturnIndexOfElement()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.SetElement(1, 100);

            Assert.Equal(1, testArray.IndexOf(100));
            Assert.Equal(-1, testArray.IndexOf(10));
        }

        public void Insert_TestInsertMethod_ShouldreturnNewSizeAndCorrectElementInCorrectIndex()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Insert(1, 100);

            Assert.Equal(4, testArray.Count());
            Assert.Equal(100, testArray.Element(1));
        }

        public void Clear_TestClearMethod_ShouldRemoveAllElements()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Clear();

            Assert.Equal(0, testArray.Count());
        }

        public void Remove_TestRemoveMethod_ShouldRemoveCorrectElement()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Remove(2);

            Assert.Equal(2, testArray.Count());
            Assert.Equal(3, testArray.Element(1));
        }

        public void RemoveAt_TestRemoveAtMethod_ShouldRemoveElementAtCorrectIndex()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.RemoveAt(1);

            Assert.Equal(2, testArray.Count());
            Assert.Equal(3, testArray.Element(1));
        }
    }
}