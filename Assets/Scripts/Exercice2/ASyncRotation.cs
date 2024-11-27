using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class ASyncRotation : MonoBehaviour
{
    private Task _task;
    private CancellationTokenSource _source;
    // Exercice 2

    public void Rotate()
    {
        if (_source != null)
        {
            _source.Cancel();
        }

        _source = new CancellationTokenSource();
        _task = RotateCube(_source.Token);
    }

    public async Task RotateCube(CancellationToken token)
    {
        var timer = 0f;

        while (timer < 5f)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            timer += Time.deltaTime;
            gameObject.transform.Rotate(transform.rotation.x + 60, 0, 0);
            await UniTask.WaitForEndOfFrame(this);
        }

        await Task.CompletedTask;
    }

    public void StopRotation()
    {
        _source.Cancel();
    }
}