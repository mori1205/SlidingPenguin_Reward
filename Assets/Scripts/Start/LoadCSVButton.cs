using UnityEngine;
using UnityEngine.UI;

public class LoadCSVButton : MonoBehaviour
{
    [SerializeField]
    private ParameterReader parameterReader;

    private Button readCSVButton;

    // Start is called before the first frame update
    void Start()
    {
        readCSVButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // parameter.csv�ɋL�q���ꂽ�p�����[�^�����ƂɘA���Ŏ��s���s���ꍇ���A���s�񐔂�0�ȉ��iparameter.csv�Ƀp�����[�^���L�q����Ă��Ȃ��j�̏ꍇ
        readCSVButton.interactable = !ParameterManager.continuousPlay && ExperimentManager.trialNum > 0;
    }

    public void OnClickButton()
    {
        parameterReader.SetParameters(1);
    }
}
