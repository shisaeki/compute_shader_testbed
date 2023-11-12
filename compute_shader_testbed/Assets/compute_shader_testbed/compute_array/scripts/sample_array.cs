using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample_array : MonoBehaviour
{
    public ComputeShader	compute_shader;
    private ComputeBuffer	compute_buffer;

    void Start()
    {
        int		indexA;
        int		indexB;
		int[]	result;

		indexA = compute_shader.FindKernel("KernelA");
		result = new int[4];
		compute_buffer = new ComputeBuffer(4, sizeof(float));
		compute_shader.SetBuffer(indexA, "_buffer", compute_buffer);
		compute_shader.SetInt("_value", 2);
		compute_shader.Dispatch(indexA, 1, 1, 1);
		compute_buffer.GetData(result);

		Debug.Log("RESULT: A");
		for (int i = 0; i < 4; i++)
		{
			Debug.Log(result[i]);
		}

		compute_buffer.Release();
    }
}
