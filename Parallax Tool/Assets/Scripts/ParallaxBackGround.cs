using StarterKit.Base;
using UnityEngine;

public class ParallaxBackGround : BaseObject,IUpdateable
{
    [SerializeField]
    GameObject _targetCam;

    [SerializeField]
    private GameObject[] ParallaxLayers;
    private Camera _parallaxCamera;
    private Vector2 _screenBounds; 
    
    private Vector2 _lastScreenPosition;

    public override void BaseObjectStart()
    {
        _parallaxCamera = GetComponent<Camera>();
        _screenBounds = _parallaxCamera.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,
        _parallaxCamera.transform.position.z));//(8.0 , 5.0)

        foreach (GameObject obj in ParallaxLayers)
        {
            loadLayers(obj);
        }

        _lastScreenPosition = transform.position;
    }
    public void IUpdate()
    {     
        transform.position = new Vector3(_targetCam.transform.position.x,_targetCam.transform.position.y,
        transform.position.z);
    }
    
    public void IFixedUpdate()
    {
        //
    }

    public void ILateUpdate()
    {
        foreach (GameObject obj in ParallaxLayers)
        {
            repositionChildObjects(obj);
            float parallaxSpeed = 1 - Mathf.Clamp01(Mathf.Abs(transform.position.z / obj.transform.position.z)); 
            float difference = transform.position.x - _lastScreenPosition.x;
            obj.transform.Translate(Vector3.right * difference * parallaxSpeed);
        }
        _lastScreenPosition = transform.position;
    }
    void loadLayers(GameObject obj)
    {
       float layerWidth =  obj.GetComponent<SpriteRenderer>().bounds.size.x;
       // the screen size is multiplied by 5 and divided by layerWidth, so that we could get the number how many sprite we need.
       int layersNeeded = (int)Mathf.Ceil(_screenBounds.x * 5 / layerWidth); 

       GameObject clone = Instantiate(obj) as GameObject;

       for(int i=0; i<layersNeeded; i++)
       {
           GameObject c = Instantiate(clone) as GameObject; //we instantiate an object of clone
           
           c.transform.SetParent(obj.transform); // we set this object as a parent of clone object
           c.transform.position = new Vector3(layerWidth * i , obj.transform.position.y,obj.transform.position.z);
           c.name = obj.name +i; 
       }

       Destroy(clone);
       Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void repositionChildObjects(GameObject obj)
    {
        //Each sprite moves separately
        //we get the transforms of child sprites.
        Transform[] children = obj.GetComponentsInChildren<Transform>();

        if(children.Length>1)
        {
            GameObject firstChild = children[1].gameObject; // [1] first child [2] lastchild [0] middle
            GameObject lastChild = children[children.Length -1].gameObject;
            
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            
            //if this x axis of this cam position and plus screenBound.x is greater than last child x axis and half value of object, 
            //then set this as a lastChild.
            if(transform.position.x + _screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling(); 
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2,
                lastChild.transform.position.y , lastChild.transform.position.z);
            }
            //vice versa 
            else if(transform.position.x - _screenBounds.x < firstChild.transform.position.x + halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth *2 ,firstChild.transform.position.y,
                firstChild.transform.position.z);
            }
        }
    }


}
