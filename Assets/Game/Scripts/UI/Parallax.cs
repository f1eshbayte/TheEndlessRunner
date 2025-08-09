using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _moveToX;
    private RawImage _image;
    
    private float _imagePositionX;
    private float _imagePositionY;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        if (_moveToX)
            MoveToX();
        else
            MoveToY();
    }

    private void MoveToX()
    {
        _imagePositionX += _speed * Time.deltaTime;

        if (_imagePositionX > 1) 
            _imagePositionX = 0;

        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }

    private void MoveToY()
    {
        _imagePositionY += _speed * Time.deltaTime;

        if (_imagePositionY > 1) 
            _imagePositionY = 0;

        _image.uvRect = new Rect(0, _imagePositionY, _image.uvRect.width, _image.uvRect.height);
    }
}