using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
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
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
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

    // Add more test cases as needed below.
}