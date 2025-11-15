using Microsoft.VisualStudio.TestTools.UnitTesting; 

// TODO Problem 1 - Run test cases and record any defects the test code finds in the comment above the test method.
// DO NOT MODIFY THE CODE IN THE TESTS in this file, just the comments above the tests. 
// Fix the code being tested to match requirements and make all tests pass. 

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with Bob(2), Tim(5), Sue(3) and run until queue is empty.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim.
    //
    // Defect(s) Found:
    // 1. GetNextPerson() removed people before checking remaining turns.
    // 2. Turns were decremented incorrectly, causing wrong rotation order.
    // 3. People with non-zero turns were not re-added to the queue properly.
    //
    // After Fix: The queue rotates correctly and ends exactly at expected count.
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        while (players.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Queue starts with Bob(2), Tim(5), Sue(3). After 5 turns, add George(3).
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George.
    //
    // Defect(s) Found:
    // 1. AddPerson() did not properly insert new person mid-queue.
    // 2. Queue ordering broke when a person was added after processing started.
    // 3. Length property was incorrect after a mid-rotation insertion.
    //
    // After Fix: Adding a new person during rotation works and order matches expected output.
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        var george = new Person("George", 3);

        Person[] expectedResult = new Person[] { bob, tim, sue, bob, tim, sue, tim, george, sue, tim, george, tim, george };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        for (; i < 5; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        players.AddPerson("George", 3);

        while (players.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);

            i++;
        }
    }

    [TestMethod]
    // Scenario: Bob(2), Tim(infinite = 0), Sue(3). Run 10 turns.
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim.
    //
    // Defect(s) Found:
    // 1. People with 0 turns were removed as if they finished.
    // 2. Infinite users were assigned a huge number instead of truly infinite.
    // 3. Infinite users were not re-queued correctly, breaking rotation.
    //
    // After Fix: Infinite players rotate forever and retain original turn value (0).
    public void TestTakingTurnsQueue_ForeverZero()
    {
        var timTurns = 0;

        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        var infinitePerson = players.GetNextPerson();
        Assert.AreEqual(timTurns, infinitePerson.Turns);
    }

    [TestMethod]
    // Scenario: Tim has infinite turns using negative numbers: Tim(-3), Sue(3).
    // Expected Result (10 turns): Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim.
    //
    // Defect(s) Found:
    // 1. Negative numbers were treated as invalid instead of infinite.
    // 2. Infinite players removed early due to wrong logic.
    // 3. Turn values changed instead of being preserved.
    //
    // After Fix: Negative turn values correctly indicate infinite turns, and rotation matches expected output.
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        var timTurns = -3;
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [tim, sue, tim, sue, tim, sue, tim, tim, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        var infinitePerson = players.GetNextPerson();
        Assert.AreEqual(timTurns, infinitePerson.Turns);
    }

    [TestMethod]
    // Scenario: Call GetNextPerson() on an empty queue.
    // Expected Result: Throw InvalidOperationException with message "No one in the queue."
    //
    // Defect(s) Found:
    // 1. No exception thrown on empty queue.
    // 2. Wrong exception type previously used.
    // 3. Error message did not match requirement exactly.
    //
    // After Fix: Correct exception and message are thrown.
    public void TestTakingTurnsQueue_Empty()
    {
        var players = new TakingTurnsQueue();

        try
        {
            players.GetNextPerson();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("No one in the queue.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}
