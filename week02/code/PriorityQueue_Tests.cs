using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// W02 - PriorityQueue Tests
// Test cases + documented test results (PROBLEM 2)

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items Low(1), Medium(5), High(10)
    // Expected Result: Dequeue returns High → Medium → Low
    //
    // Defect(s) Found:
    // 1. Original code searched for LOWEST priority instead of HIGHEST.
    //    (Used < instead of > when comparing priorities.)
    // 2. Because of this, items came out reversed or incorrect.
    //
    // Test Result After Fix:
    // ✔ Highest priority is removed first exactly as expected.
    public void TestPriorityQueue_HighPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);

        var first = pq.Dequeue();
        var second = pq.Dequeue();
        var third = pq.Dequeue();

        Assert.AreEqual("High", first);
        Assert.AreEqual("Medium", second);
        Assert.AreEqual("Low", third);
    }


    [TestMethod]
    // Scenario: Enqueue A(5), B(5), C(5) — same priority
    // Expected Result: Dequeue preserves insertion order → A, B, C
    //
    // Defect(s) Found:
    // 1. Original Dequeue only looked for > priority.
    //    When priorities were equal, it *skipped* later items, breaking FIFO.
    //
    // Test Result After Fix:
    // ✔ Equal-priority items come out in FIFO order.
    public void TestPriorityQueue_EqualPriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);

        var first = pq.Dequeue();
        var second = pq.Dequeue();
        var third = pq.Dequeue();

        Assert.AreEqual("A", first);
        Assert.AreEqual("B", second);
        Assert.AreEqual("C", third);
    }


    [TestMethod]
    // Scenario: Calling Dequeue() on an empty queue
    // Expected Result: InvalidOperationException with message:
    //   "The queue is empty."
    //
    // Defect(s) Found:
    // 1. Original code did not properly guard against empty queue.
    //
    // Test Result After Fix:
    // ✔ Correct exception thrown with correct message.
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            pq.Dequeue();
        });

        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}
