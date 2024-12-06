using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using QFSW.QC;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject spawnObjectPrefab;
    private GameObject spawnedObject;


    private NetworkVariable<MyCustomData> randomNumber = new NetworkVariable<MyCustomData>(new MyCustomData
    {
        _int = 50,
        _bool = true
    }, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public struct MyCustomData : INetworkSerializable
    {
        public int _int;
        public bool _bool;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _int);
            serializer.SerializeValue(ref _bool);
        }
    }

    public override void OnNetworkSpawn()
    {
        randomNumber.OnValueChanged += OnRandomNumberChanged;
    }

    private void OnRandomNumberChanged(MyCustomData previousValue, MyCustomData newValue)
    {
        Debug.Log(OwnerClientId + "; Random Number: " + newValue._int + "; " + newValue._bool);
    }

    private void Update()
    {

        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.T))
        {
            spawnedObject = Instantiate(spawnObjectPrefab);
            spawnedObject.GetComponent<NetworkObject>().Spawn(true);
            //TestServerRpc();
            /*
            randomNumber.Value = new MyCustomData {

                _int = Random.Range(0, 100),
                _bool = !randomNumber.Value._bool
            };
            */
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            spawnedObject.GetComponent<NetworkObject>().Despawn(true);
            Destroy(spawnedObject);
        }
    

        Vector3 moveDir = new Vector3(0,0,0);

        if(Input.GetKey(KeyCode.W)) moveDir.z += 1f;
        if(Input.GetKey(KeyCode.S)) moveDir.z -= 1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x -= 1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x += 1f;

        float moveSpeed = 3f;

        if(moveDir.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
        }

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    [ServerRpc]
    private void TestServerRpc()
    {
        Debug.Log("TestServerRpc " + OwnerClientId);
    }



    [Command("message-test")]
    private void MessageTest()
    {
        //Test quantum console
        Debug.Log("MENSAGEM");
    }
}
