﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class PanelUpdate : MonoBehaviour {

	GameObject panel_alert;
	Text text_msg;
	void Awake() {
		text_msg = transform.Find("Text msg").GetComponent<Text>();
		panel_alert = transform.Find("PanelAlert").gameObject;
		panel_alert.SetActive(false);
	}


	bool bDownloading = false;

	void Start() {

		RequestVersion();
	}

	public void RequestVersion() {
		panel_alert.SetActive(false);
		text_msg.text = "检查更新";
		UpdateManager.GetInstance().RequestVersion(delegate (WWW www){
			if (www.error != null) {
				Debug.LogError("downloading error! " + www.error);
				panel_alert.SetActive(true);
				text_msg.text = "更新失败";
				return;
			}

			bool bNeedUpdate = UpdateManager.GetInstance().CompareVersion(www.text);

			// download resources
			if (bNeedUpdate) {
				string[] files = UpdateManager.GetInstance().UpdateFiles;
				int count = 1;
				AssetBundleManager.GetInstance().SetDownloadCallback(delegate {
					text_msg.text = string.Format("更新资源({0}/{1})", count++, files.Length);
				});
				for(int i = 0; i < files.Length; i ++) {
					AssetBundleManager.AddDownloadAssetBundle(files[i]);
				}
				bDownloading = true;
			} else {
				// load local assetbundle
				Dictionary<string, string> localfiles = UpdateManager.GetInstance().LocalFiles;
				foreach(string file in localfiles.Keys) {
					AssetBundleManager.GetInstance().LoadAssetBundleLocal(file);
				}

				bDownloading = true;
			}
		});
	}

	void Update() {
		
		if (bDownloading) {
			if (AssetBundleManager.GetDownloadingWWWNum() == 0 && 
				AssetBundleManager.GetToDownloadAssetBundleNum() == 0 ) {
				OnDownloadFinish();
				bDownloading = false;
			}
		}
	}


	// 更新检查完成
	void OnDownloadFinish() {

		AssetBundleManager.InitDependenceInfo ();

		UpdateManager.GetInstance().UpdateVersion();

		ResourceManager.GetInstance().Init();

		LanguageManager.GetInstance().Init();

		// 初始化lua engine
		LuaManager luaManager = LuaManager.GetInstance(true);
		luaManager.InitStart();
		luaManager.DoFile("Game");
		Util.CallMethod("Game", "OnInitOK");
	}
}
