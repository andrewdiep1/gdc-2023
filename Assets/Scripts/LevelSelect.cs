using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public List<Sprite> albums = new List<Sprite>();
    public List<AudioClip> clips = new List<AudioClip>();
    public SpriteRenderer spriteRenderer;

    private AudioSource audioSource;
    private int selectedScene;
    private int selectedSong;

    void Start()
    {
        print("album count: " + albums.Count);
        print("clips count: " + clips.Count);

        selectedScene = 0;
        selectedSong = 0;

        // Initialize to the first album and audio clip
        if (albums.Count > 0 && clips.Count > 0)
        {
            spriteRenderer.sprite = albums[0];
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = clips[0];
            audioSource.Play();
            Debug.Log($"Playing {audioSource.clip.name}");
        }
        else
        {
            Debug.LogWarning("Albums or clips list is empty.");
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            nextSong();
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            backSong();
        }
    }

    public void nextSong() {
        selectedSong = (selectedSong + 1) % albums.Count;
        spriteRenderer.sprite = albums[selectedSong];

        selectedScene = (selectedScene + 1) % clips.Count;
        audioSource.clip = clips[selectedScene];

        Debug.Log($"Playing {audioSource.clip.name}");
        audioSource.Play();
    }

    public void backSong() {
        selectedSong = (selectedSong - 1 + albums.Count) % albums.Count;
        spriteRenderer.sprite = albums[selectedSong];

        selectedScene = (selectedScene - 1 + clips.Count) % clips.Count;
        audioSource.clip = clips[selectedScene];
        Debug.Log($"Playing {audioSource.clip.name}");
        audioSource.Play();
    }

    public void PlayGame() {
        Debug.Log(spriteRenderer.sprite.name);
        SceneManager.LoadScene(spriteRenderer.sprite.name);
    }
}
