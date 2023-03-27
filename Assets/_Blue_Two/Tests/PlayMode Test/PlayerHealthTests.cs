using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerHealthTests
{
    public GameObject TestPlayer;
    public GameObject ScriptLoadedPlayer;

    [SetUp]
    public void Setup()
    {
        TestPlayer = GameObject.Instantiate(new GameObject());
        ScriptLoadedPlayer = TestPlayer.AddComponent<PlayerHealth>().gameObject;
        ScriptLoadedPlayer = ScriptLoadedPlayer.AddComponent<Rigidbody2D>().gameObject;
        ScriptLoadedPlayer = ScriptLoadedPlayer.AddComponent<Animator>().gameObject;

    }

    [UnityTest]
    public  IEnumerator PlayerMoverComponentRequirementTest()
    {
        yield return null;

        Assert.NotNull(ScriptLoadedPlayer.GetComponent<PlayerHealth>(), "Enemy has rigidbody2d attached.");

    }

    [UnityTest]
    public IEnumerator PlayerMoverWillMoveAfterGameStarts()
    {
        Vector2 position = ScriptLoadedPlayer.transform.position;

        yield return new WaitForSeconds(0.1f);
        
        Vector2 newPosition = ScriptLoadedPlayer.transform.position;

        Assert.AreNotEqual(newPosition, position, "PlayerMoveTestPassed. Player is affected by gravity.");
    }
}
