using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SimpleTank : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 100.0f;    
    public GameObject bulletPrefab;
    public Transform bulletOrigin;

    public float shotPower = 5000.0f;
    private void Update() {
        if(photonView.IsMine)
        {
            ProcessInput();
        }
    }
    public void ProcessInput()
    {
        //Deplacement du tank
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        //Rotation avec la souris
        transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X"),0)*Time.deltaTime * rotateSpeed);

        if(Input.GetMouseButtonDown(0))
        {
            photonView.RPC("Fire",RpcTarget.AllViaServer, bulletOrigin.position, bulletOrigin.forward);
        }
    }
    [PunRPC]
    public void Fire (Vector3 pos, Vector3 dir, PhotonMessageInfo info)
    {
        GameObject bullet;

        bullet= Instantiate(bulletPrefab, pos , Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(dir * shotPower);
    }
}
