using UnityEngine;

public class Fixed : MonoBehaviour
{
    private void Start()
    {
        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장
        if (deviceWidth > deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            Debug.Log("rotate");
        }
    }

    
}