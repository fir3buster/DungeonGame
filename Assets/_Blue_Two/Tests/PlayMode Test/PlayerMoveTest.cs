using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayerMoveTests
{
    public GameObject TestPlayer;
    public GameObject ScriptLoadedPlayer;
    public GameObject TestBlock;
    public GameObject RdyBlock;
    public GameObject PlayerRdy;

    [SetUp]
    public void Setup()
    {
        TestBlock = GameObject.Instantiate(new GameObject(), new Vector2(0,0), Quaternion.identity);
        RdyBlock = TestBlock.AddComponent<BoxCollider2D>().gameObject;

        TestPlayer = GameObject.Instantiate(new GameObject(), new Vector2(0,5), Quaternion.identity);
        ScriptLoadedPlayer = TestPlayer.AddComponent<playerMove>().gameObject;
        ScriptLoadedPlayer = ScriptLoadedPlayer.AddComponent<Rigidbody2D>().gameObject;
        ScriptLoadedPlayer = ScriptLoadedPlayer.AddComponent<Animator>().gameObject;
        PlayerRdy = ScriptLoadedPlayer.AddComponent<BoxCollider2D>().gameObject;

    }

    [UnityTest]
    public  IEnumerator PlayerMoverComponentRequirementTest()
    {
        TestBlock = GameObject.Instantiate(new GameObject(), new Vector2(0,0), Quaternion.identity);
        RdyBlock = TestBlock.AddComponent<BoxCollider2D>().gameObject;

        TestPlayer = GameObject.Instantiate(new GameObject(), new Vector2(0,5), Quaternion.identity);
        ScriptLoadedPlayer = TestPlayer.AddComponent<playerMove>().gameObject;
        ScriptLoadedPlayer = ScriptLoadedPlayer.AddComponent<Rigidbody2D>().gameObject;
        ScriptLoadedPlayer = ScriptLoadedPlayer.AddComponent<Animator>().gameObject;
        PlayerRdy = ScriptLoadedPlayer.AddComponent<BoxCollider2D>().gameObject;

        yield return null;

        Assert.NotNull(PlayerRdy.GetComponent<playerMove>(), "Enemy has rigidbody2d attached.");

        GameObject.Destroy(PlayerRdy);
        GameObject.Destroy(RdyBlock);

    }

    [UnityTest]
    public IEnumerator PlayerMoverWillMoveAfterGameStarts()
    {
        
        TestBlock = GameObject.Instantiate(new GameObject(), new Vector2(0,0), Quaternion.identity);
        RdyBlock = TestBlock.AddComponent<BoxCollider2D>().gameObject;

        TestPlayer = GameObject.Instantiate(new GameObject(), new Vector2(0,5), Quaternion.identity);
        ScriptLoadedPlayer = TestPlayer.AddComponent<playerMove>().gameObject;
        ScriptLoadedPlayer = ScriptLoadedPlayer.AddComponent<Rigidbody2D>().gameObject;
        ScriptLoadedPlayer = ScriptLoadedPlayer.AddComponent<Animator>().gameObject;
        PlayerRdy = ScriptLoadedPlayer.AddComponent<BoxCollider2D>().gameObject;

        Vector2 position = PlayerRdy.transform.position;

        yield return new WaitForSeconds(0.1f);
        
        Vector2 newPosition = PlayerRdy.transform.position;

        Assert.AreNotEqual(newPosition, position, "PlayerMoveTestPassed. Player is affected by gravity.");
       
        GameObject.Destroy(PlayerRdy);
        GameObject.Destroy(RdyBlock);
    }
}
