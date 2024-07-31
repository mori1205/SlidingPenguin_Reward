using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinuousPlayToggleController : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = ParameterManager.continuousPlay;

        // WebGL�̏ꍇ�������́A���s�񐔂�0�ȉ��iparameter.csv�Ƀp�����[�^���L�q����Ă��Ȃ��j�̏ꍇ�ACSV�t�@�C�����g�������͂��ł��Ȃ����߁A�g�O���𑀍�ł��Ȃ��悤�ɂ���
        toggle.interactable = Application.platform != RuntimePlatform.WebGLPlayer && ExperimentManager.trialNum > 0;
    }

    public void SetSetting()
    {
        ParameterManager.continuousPlay = toggle.isOn;
    }
}
