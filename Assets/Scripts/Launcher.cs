using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Launcher : NetworkLauncher
{
    // Start is called before the first frame update
    async void Start()
    {
        await Task.Yield();
        
            if (CMD.isHealess())
            {
                if (CMD.TryGetParams(out string port, "-port", "-Port", "-PORT"))
                {
                    CMD.TryGetParams(out string ip, "-ip", "-IP");
                    CMD.TryGetParams(out string roomName, "-roomName", "-roomname");
                    ushort newport = (ushort)Int32.Parse(port);
                    await StartServer(roomName, newport, ip);
                    Debug.Log($"Server start with ip: {ip} , port: {port}, roomname: {roomName}");
                };
            }
            else
            {
                Application.Quit();
            };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
