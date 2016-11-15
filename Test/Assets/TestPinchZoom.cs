using UnityEngine;
using System.Collections;

public class TestPinchZoom : MonoBehaviour {
    //param
    [System.Serializable]
    public class Param{
        public float minSpeed;
        public float maxSpeed;

        public bool isLimit;
        public float minLimit;
        public float maxLimit;

        public Param(float minSpeed, float maxSpeed)
        {
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
        }

        public Param(float minSpeed, float maxSpeed, bool isLimit, float minLimit, float maxLimit)
        {
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
            this.isLimit = isLimit;
            this.minLimit = minLimit;
            this.maxLimit = maxLimit;
        }
    }

    //Config
    [SerializeField]
    Configuration config = new Configuration();
    public Configuration Config { get { return this.config; } set { this.config = value; } }
    [System.Serializable]
    public class Configuration
    {
        public Vector3 defultPosition;
        //zoom
        public ConfigZoom zoom = new ConfigZoom();
    }

    
    //Config zoom
    [System.Serializable]
    public class ConfigZoom
    {
        public Param param = new Param(5, 10, true, 0, 50);

        private float zoomAmount;
        public float ZoomAmount
        {
            get { return zoomAmount; }
            set 
            {
                zoomAmount = value;
                TestPinchZoom.Limit(param, ref zoomAmount);
                
            }
        }

        private float idearZoomAmount;
        public float IdearZoomAmount
        {
            get { return idearZoomAmount; }
            set 
            {
                idearZoomAmount = value;
                TestPinchZoom.Limit(param, ref idearZoomAmount);
            }
        }
        
        public Property prop;
        [System.Serializable]
        public struct Property
        {
            public float speed;
            public float moothSpeed;
        };
        
    }

    #region PinchZoom
    void SetPinchZoom()
    {
        this.Config.zoom.ZoomAmount = Mathf.Lerp(this.Config.zoom.ZoomAmount, this.Config.zoom.IdearZoomAmount, this.Config.zoom.prop.moothSpeed * Time.deltaTime);
        transform.position = this.Config.defultPosition + this.Config.zoom.ZoomAmount * transform.forward;
    }

    void OnPinch(PinchGesture gesture)
    {
        this.Config.zoom.IdearZoomAmount += this.Config.zoom.prop.speed * gesture.Delta.Centimeters();
    }
    #endregion

    void Start()
    {
        this.SetDefult();
    }

    void Update()
    {
        this.SetPinchZoom();
        
    }

    void SetDefult()
    {
        this.Config.defultPosition = transform.position;
    }

    static void Limit(Param param, ref float value)
    {
        value = Mathf.Clamp(value, param.minLimit, param.maxLimit);
    }
    
}
