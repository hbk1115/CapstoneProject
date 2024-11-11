using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static AudioManager;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("BGM")]
    public AudioClip[] bgmClips;
    public float bgmVolume;
    public int bgmChannels;
    AudioSource[] bgmPlayer;
    [SerializeField] private Slider bgmVolumeSlider;
    //AudioHighPassFilter
    Bgm currentBgm;

    [Header("SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    [SerializeField] private Slider volumeSlider;

    public enum Bgm
    {
        main,
        inBattle,
        inBossBattle
    }
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
        if (instance == null)
        {
            instance = this; // 인스턴스 설정
            DontDestroyOnLoad(gameObject); // 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 존재하면 현재 오브젝트를 파괴
        }
        Init();

        GameManager.instance.pauseMenu.sfxSlider.maxValue = 1;
        GameManager.instance.pauseMenu.sfxSlider.minValue = 0;
        GameManager.instance.pauseMenu.sfxSlider.value = PlayerPrefs.GetFloat("GameVolume", 0.03f);

        GameManager.instance.pauseMenu.bgmSlider.maxValue = 1;
        GameManager.instance.pauseMenu.bgmSlider.minValue = 0;
        GameManager.instance.pauseMenu.bgmSlider.value = PlayerPrefs.GetFloat("BgmGameVolume", 0.03f);

    }
    private void Update()
    {
        bgmVolume = GameManager.instance.pauseMenu.bgmSlider.value;
        PlayerPrefs.SetFloat("BgmGameVolume", bgmVolume); // 음량을 PlayerPrefs에 저장
        PlayerPrefs.Save(); // 변경 사항 저장

        for (int index = 0; index < bgmPlayer.Length; index++)
        {
            bgmPlayer[index].volume = bgmVolume;
        }

        sfxVolume = GameManager.instance.pauseMenu.sfxSlider.value;
        PlayerPrefs.SetFloat("GameVolume", sfxVolume); // 음량을 PlayerPrefs에 저장
        PlayerPrefs.Save(); // 변경 사항 저장
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    void Init()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = new AudioSource[bgmChannels];

        for (int index = 0; index < bgmPlayer.Length; index++)
        {
            bgmPlayer[index] = bgmObject.AddComponent<AudioSource>();
            bgmPlayer[index].playOnAwake = false;
            bgmPlayer[index].loop = true;
            bgmPlayer[index].volume = bgmVolume;
            //bgmPlayer[index].clip = bgmClip;
        }

        


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
    public void PlayNewBgm(Bgm bgm)
    {
        StopAllBgm();//전부 스탑하고 시작(bgm은 하나임)
        bgmPlayer[(int)bgm].clip = bgmClips[(int)bgm];
        bgmPlayer[(int)bgm].Play();
        currentBgm = bgm;
    }

    public void ResumeBgm()
    {
        bgmPlayer[(int)currentBgm].clip = bgmClips[(int)currentBgm];
        bgmPlayer[(int)currentBgm].Play();
    }

    public void PauseBgm()
    {
        bgmPlayer[(int)currentBgm].clip = bgmClips[(int)currentBgm];
        bgmPlayer[(int)currentBgm].Pause();
    }
    private void StopAllBgm()
    {
        for (int index = 0; index < bgmPlayer.Length; index++)
        {
            bgmPlayer[index].Stop();
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
