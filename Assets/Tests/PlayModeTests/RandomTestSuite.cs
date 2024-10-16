using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class RandomTestSuite
{
    private GameObject player;
    private Player playerScript;  // Reference to the Player script
    private System.Random random;
    private StreamWriter logFile;
    private GameObject target;
    public int maxMove = 50;

    private enum MovementDirection
    {
        W,  // Forward
        A,  // Left
        S,  // Backward
        D   // Right
    }

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Load the test scene
        SceneManager.LoadScene("1-2 Enemy"); // Ensure the correct scene is loaded for testing
        yield return null; // Wait for the scene to load

        // Find the player object
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();
        target = GameObject.FindWithTag("Target");
        random = new System.Random();

        // Open or create a log file
        logFile = new StreamWriter("RandomTestLog.txt", append: true);
        logFile.WriteLine("===== Test Start: " + DateTime.Now + " =====");
        logFile.Flush();
    }

    [UnityTest]
    public IEnumerator RandomMovementTest()
    {
        Vector3 initialPosition = player.transform.position;
        logFile.WriteLine("Initial Player Position: " + initialPosition);

        for (int i = 0; i < maxMove; i++)
        {
            if (ReachTarget())
            {
                logFile.WriteLine("Reached target at: " + target.transform.position);
                break;
            }
                
            MovementDirection direction = GetRandomDirection();
            logFile.WriteLine("Move #" + (i + 1) + ": " + direction);

            yield return SimulateMovement(direction);

            logFile.WriteLine("Player New Position: " + player.transform.position);
            logFile.Flush();
        }

        // Add assertions as needed to check final state
        Assert.Pass();  // Placeholder, you can validate position or player state here
    }

    // Generates a random direction using the MovementDirection enum
    private MovementDirection GetRandomDirection()
    {
        Array directions = Enum.GetValues(typeof(MovementDirection));
        return (MovementDirection)directions.GetValue(random.Next(directions.Length));
    }

    private IEnumerator SimulateMovement(MovementDirection direction)
    {
        switch (direction)
        {
            case MovementDirection.W:  // Forward
                Debug.Log("Simulating W Key (Forward)");
                PressKey(KeyCode.W);
                break;
            case MovementDirection.S:  // Backward
                Debug.Log("Simulating S Key (Backward)");
                PressKey(KeyCode.S);
                break;
            case MovementDirection.A:  // Left
                Debug.Log("Simulating A Key (Left)");
                PressKey(KeyCode.A);
                break;
            case MovementDirection.D:  // Right
                Debug.Log("Simulating D Key (Right)");
                PressKey(KeyCode.D);
                break;
        }

        yield return new WaitForSeconds(1);  // Wait for movement to complete
    }

    // Helper function to simulate key presses
    private void PressKey(KeyCode keyCode)
    {
        if (keyCode == KeyCode.W)
        {
            if (playerScript.CanMoveForward)
                playerScript.MoveForward();
            else
                logFile.WriteLine("Player cannot move forward now.");
        }
        if (keyCode == KeyCode.S)
        {
            if (playerScript.CanMoveBack)
                playerScript.MoveBack();
            else
                logFile.WriteLine("Player cannot move backward now.");
        }
        if (keyCode == KeyCode.A)
        {
            if (playerScript.CanMoveLeft)
                playerScript.MoveLeft();
            else
                logFile.WriteLine("Player cannot move left now.");
        }
        if (keyCode == KeyCode.D)
        {
            if (playerScript.CanMoveRight)
                playerScript.MoveRight();
            else
                logFile.WriteLine("Player cannot move right now.");
        }
        logFile.Flush();
    }

    // Reach Target?
    private bool ReachTarget()
    {
        if (player.transform.position == target.transform.position)
            return true;
        return false;
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        player = null;

        // Close the log file at the end of the test
        logFile.WriteLine("===== Test End: " + DateTime.Now + " =====");
        logFile.Close();
        yield return null;
    }
}
