using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestSuite
{
    private GameObject player;
    private Player playerScript;  // Reference to the Player script
    private float playerSpeed;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Load the test scene
        SceneManager.LoadScene("1-1 WASD"); // Ensure the correct scene is loaded for testing
        yield return null; // Wait for the scene to load

        // Find the player object
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();

        playerSpeed = playerScript.PlayerSpeed;  // Store player speed for tests
    }

    [UnityTest]
    public IEnumerator PlayerMovesForward_WhenPressingW()
    {
        Vector3 initialPosition = player.transform.position;

        // Simulate pressing the "W" key (Move forward)
        PressKey(KeyCode.W);
        yield return new WaitForSeconds(playerSpeed); // Wait for the movement to complete

        Vector3 newPosition = player.transform.position;
        Assert.AreEqual(initialPosition + Vector3.forward, newPosition);  // Validate movement
    }

    [UnityTest]
    public IEnumerator PlayerMovesBackward_WhenPressingS()
    {
        Vector3 initialPosition = player.transform.position;

        // Simulate pressing the "S" key (Move back)
        PressKey(KeyCode.S);
        yield return new WaitForSeconds(playerSpeed);

        Vector3 newPosition = player.transform.position;
        Assert.AreEqual(initialPosition + Vector3.back, newPosition);  // Validate movement
    }

    [UnityTest]
    public IEnumerator PlayerMovesLeft_WhenPressingA()
    {
        Vector3 initialPosition = player.transform.position;

        // Simulate pressing the "A" key (Move left)
        PressKey(KeyCode.A);
        yield return new WaitForSeconds(playerSpeed);

        Vector3 newPosition = player.transform.position;
        Assert.AreEqual(initialPosition + Vector3.left, newPosition);  // Validate movement
    }

    [UnityTest]
    public IEnumerator PlayerMovesRight_WhenPressingD()
    {
        Vector3 initialPosition = player.transform.position;

        // Simulate pressing the "D" key (Move right)
        PressKey(KeyCode.D);
        yield return new WaitForSeconds(playerSpeed);

        Vector3 newPosition = player.transform.position;
        Assert.AreEqual(initialPosition + Vector3.right, newPosition);  // Validate movement
    }

    // Helper function to simulate key presses
    private void PressKey(KeyCode keyCode)
    {
        if (keyCode == KeyCode.W && playerScript.CanMoveForward)
            playerScript.MoveForward();
        if (keyCode == KeyCode.S && playerScript.CanMoveBack)
            playerScript.MoveBack();
        if (keyCode == KeyCode.A && playerScript.CanMoveLeft)
            playerScript.MoveLeft();
        if (keyCode == KeyCode.D && playerScript.CanMoveRight)
            playerScript.MoveRight();
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        player = null;
        yield return null;
    }
}
