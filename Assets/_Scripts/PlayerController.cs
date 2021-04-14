using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public TextMeshProUGUI textBaloon;
    public TextMeshProUGUI inputField;

    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        else
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                CmdFire();
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                CmdSetColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
            }

            if(Input.GetKeyDown(KeyCode.Return))
            {
                CmdSendText();
            }
        }
    }

    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2f);
    }

    [Command]
    void CmdSetColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
        RpcChangeColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
    }

    [ClientRpc]
    void RpcChangeColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    [Command]
    void CmdSendText()
    {
        textBaloon.text += inputField.text + "\n";
        Debug.Log("Text Baloon = " + inputField.text);
        RpcReceiveText(inputField.text + "\n");
    }

    [ClientRpc]
    void RpcReceiveText(string text)
    {
        Debug.Log("Text = " + text);
        textBaloon.text = text;
    }

    //FLUXO
    /*
        command
        manda a info pro server
        rpc
        server manda a info pros clients
     */
}
