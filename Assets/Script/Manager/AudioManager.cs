using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    [SerializeField] private Slider volumeSlider;

    public enum Sfx
    {
        select_button,
        select_card,
        player_hit,
        enemy_hit,
        enemy_death,
        get_coin,
        buy_item,
        fire_hit,
        ice_hit,
        plague_hit,
        normal_hit,
        fire_indent,
        ice_indent,
        plague_indent,
        open_door,
        heal_1,
        heal_2
    }

    private void Awake()
    {
        instance = this;
        Init();
        volumeSlider.maxValue = 1;
        volumeSlider.minValue = 0;
        volumeSlider.value = 0.01f;
    }
    private void Update()
    {
        sfxVolume = volumeSlider.value;
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    void Init()
    {
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].bypassListenerEffects = true;
            sfxPlayers[index].volume = sfxVolume;
        }
    }
    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
