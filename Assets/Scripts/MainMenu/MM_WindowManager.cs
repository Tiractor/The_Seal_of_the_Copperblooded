using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_WindowManager : MonoBehaviour
{
    public List<Animator> Windows = new List<Animator>();
    private Animator OpenWindow;
    //private bool Closing = false;
    private bool Check(Animator WhichWindow)
    {
        foreach (var anim in Windows)
        {
            if(anim.name == WhichWindow.name) return true;
        }
        return false;
    }
    public void StartOpeningWindow(Animator WhichWindow)
    {
        if (!Check(WhichWindow))
        {
            Core.Logger.Error(WhichWindow.name + " - not Window, which MM_WM control");
            return;
        }
        if(OpenWindow != null) 
        {
            OpenWindow.Play("UI_Hide");
            float hideAnimationDuration = OpenWindow.GetCurrentAnimatorStateInfo(0).length;
            OpenWindow = WhichWindow;
            StartCoroutine(WaitForAnimationEnd(hideAnimationDuration));
        }
        else
        {
            OpenWindow = WhichWindow;
            EndOpeningWindow();
        }
    }
    public void StartClosingWindow()
    {
        if (OpenWindow == null)
        {
            Core.Logger.Error("Trying close nonexist Window");
            return;
        }
        OpenWindow.Play("UI_Hide");
        OpenWindow = null;
    }
    private IEnumerator WaitForAnimationEnd(float waitTime)
    {
        // Ожидаем указанное время
        yield return new WaitForSeconds(waitTime);

        // Вызываем EndOpeningWindow после завершения ожидания
        EndOpeningWindow();
    }

    private void EndOpeningWindow()
    {
        OpenWindow.Play("UI_Apperance");
    }
}
