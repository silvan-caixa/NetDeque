namespace NetDeque.Tests;

public class DequeTests
    {

    [Fact]
    public void NewDeque_ShouldHaveCountZero()
        {
        var deque = new Deque<int>();
        Assert.Equal(0, deque.Count);
        }

    [Fact]
    public void NewDeque_ShouldBeEmpty()
        {
        var deque = new Deque<int>();
        Assert.True(deque.IsEmpty);
        }



    [Fact]
    public void AddBeg_ShouldMakePeekBegReturnSameElement()
        {
        var deque = new Deque<int>();
        deque.AddBeg(42);
        Assert.Equal(42, deque.PeekBeg());
        }

    [Fact]
    public void AddBeg_MultipleInsertions_ShouldPreserveOrder()
        {
        var deque = new Deque<string>();
        deque.AddBeg("third");
        deque.AddBeg("second");
        deque.AddBeg("first");

        Assert.Equal("first", deque.PeekBeg());
        Assert.Equal("first", deque.RemBeg());
        Assert.Equal("second", deque.RemBeg());
        Assert.Equal("third", deque.RemBeg());
        Assert.True(deque.IsEmpty);
        }

    [Fact]
    public void AddEnd_ShouldReturnElementWithPeekEnd()
        {
        var deque = new Deque<int>();
        deque.AddEnd(100);
        Assert.Equal(100, deque.PeekEnd());
        }


    [Fact]
    public void AddEnd_MultipleElements_ShouldMaintainOrder()
        {
        var deque = new Deque<int>();
        deque.AddEnd(1);
        deque.AddEnd(2);
        deque.AddEnd(3);
        Assert.Equal(3, deque.PeekEnd());
        Assert.Equal(1, deque.RemBeg());
        Assert.Equal(2, deque.RemBeg());
        Assert.Equal(3, deque.RemBeg());
        }

    }
