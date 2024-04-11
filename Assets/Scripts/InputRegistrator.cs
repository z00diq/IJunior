using UnityEngine;

public class InputRegistrator : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray,out RaycastHit hit);

            if (hit.collider == null)
                return;

            if (hit.collider.TryGetComponent(out Cube cube))
                cube.OnCubeClick();
        }
    }
}
