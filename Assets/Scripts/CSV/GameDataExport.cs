using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public enum ExportData
{
    ScoreData,
    TrailData
}

public class GameDataExport : MonoBehaviour
{
    // System.IO
    private static StreamWriter scoreSW;
    private static StreamWriter trailSW;

    public static void CreateScoreCSV()
    {
        // WebGL�̏ꍇ�́A���U���g��ʂ�CSV�t�@�C�����_�E�����[�h����
        if (Application.platform == RuntimePlatform.WebGLPlayer) { return; }

        DateTime currentTime = DateTime.Now;
        string year = currentTime.Year.ToString();
        string month = currentTime.Month.ToString();
        string day = currentTime.Day.ToString();
        string hour = currentTime.Hour.ToString();
        string minute = currentTime.Minute.ToString();
        string second = currentTime.Second.ToString();

        // SaveData�t�H���_�����݂��Ȃ��ꍇ�́A�V�������
        if (!Directory.Exists(Application.dataPath + "/ScoreData")) { Directory.CreateDirectory(Application.dataPath + "/ScoreData"); }
        scoreSW = new StreamWriter(@Application.dataPath + "/ScoreData/" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "_result.csv", 
            false, Encoding.GetEncoding("UTF-8"));

        // ���x������������
        string[] labels = { "success", "fish_number", "clear_time", "distance", "sensitivity", "limited_time", "maximum_speed", "acceleration", "friction" };

        // ������z��̂��ׂĂ̗v�f���u,�v�ŘA������
        string label = string.Join(",", labels);

        // �u,�v�ŘA�������������csv�t�@�C���֏�������
        scoreSW.WriteLine(label);
    }

    public static void CreateTrailCSV()
    {
        // WebGL�łł́A�O�Ճf�[�^�̏o�͍͂s��Ȃ�
        if (Application.platform == RuntimePlatform.WebGLPlayer) { return; }

        DateTime currentTime = DateTime.Now;
        string year = currentTime.Year.ToString();
        string month = currentTime.Month.ToString();
        string day = currentTime.Day.ToString();
        string hour = currentTime.Hour.ToString();
        string minute = currentTime.Minute.ToString();
        string second = currentTime.Second.ToString();

        // TrailData�t�H���_�����݂��Ȃ��ꍇ�́A�V�������
        if (!Directory.Exists(Application.dataPath + "/TrailData")) { Directory.CreateDirectory(Application.dataPath + "/TrailData"); }
        trailSW = new StreamWriter(@Application.dataPath + "/TrailData/" 
            + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-trial" + ExperimentManager.trialCount + "_trail.csv", 
            false, Encoding.GetEncoding("UTF-8"));

        // ���x������������
        string[] labels = { "time_stamp", "penguin_x", "penguin_y" };
        // ������z��̂��ׂĂ̗v�f���u,�v�ŘA������
        string label = string.Join(",", labels);

        // �u,�v�ŘA�������������csv�t�@�C���֏�������
        trailSW.WriteLine(label);
    }

    public static void ExportGameData(bool success, int fishNumber, string clearTime, float distance, List<Trail> trail,
        float sensitivity, int limitedTime, float maximumSpeed, float acceleration, float friction)
    {
        // WebGL�̏ꍇ�́A���U���g��ʂ�CSV�t�@�C�����_�E�����[�h����
        if (Application.platform == RuntimePlatform.WebGLPlayer) { return; }

        string[] score = { success.ToString(), fishNumber.ToString(), clearTime, distance.ToString(), 
            sensitivity.ToString(), limitedTime.ToString(), maximumSpeed.ToString(), acceleration.ToString(), friction.ToString() };
        string scoreData = string.Join(",", score);
        scoreSW.WriteLine(scoreData);

        for (int i = 0; i < trail.Count; i++)
        {
            string trailData = string.Join(",", trail[i].timeStamp, trail[i].x, trail[i].y);
            trailSW.WriteLine(trailData);
        }
        SaveCSV(ExportData.TrailData);
    }

    public static void SaveCSV(ExportData exportData)
    {
        // WebGL�̏ꍇ�́A���U���g��ʂ�CSV�t�@�C�����_�E�����[�h����
        if (Application.platform == RuntimePlatform.WebGLPlayer) { return; }

        switch (exportData)
        {
            case ExportData.ScoreData:
                scoreSW.Close();
                break;
            case ExportData.TrailData:
                trailSW.Close();
                break;
        }
    }
}
