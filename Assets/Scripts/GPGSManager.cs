using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPGSManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()      
        .RequestEmail()
        // requests a server auth code be generated so it can be passed to an
        //  associated back end server application and exchanged for an OAuth token.
        .RequestServerAuthCode(false)
        // requests an ID token be generated.  This OAuth token can be used to
        //  identify the player to other services such as Firebase.
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        Login();
    }

    // Update is called once per frame
    void Login()
    {
        if (Social.localUser.authenticated)
        {
            Debug.Log("이미 로그인된 유저");
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
                {
                    if (success)
                    {
                        Debug.Log("로그인 성공");
                    }
                    else
                    {
                        Debug.Log("로그인 실패");
                    }
                });
        }
    }
}
