using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NoteTest {
    /* Does not work at the moment!
    [UnityTest]
    public IEnumerator NoteRenderEnabled() {
        var note = new GameObject();
        note.transform.position = new Vector3(0.0f, 10.0f, 0.0f);
        note.AddComponent<SpriteRenderer>();
        note.AddComponent<Rigidbody2D>();
        note.AddComponent<Note>();

        yield return null;

        Assert.False(note.GetComponent<SpriteRenderer>().enabled);

        note.GetComponent<Note>().speed = -2;
        note.GetComponent<Note>().visibleDistance = 11;

        yield return null;

        Assert.True(note.GetComponent<SpriteRenderer>().enabled);
    }
    */
}
