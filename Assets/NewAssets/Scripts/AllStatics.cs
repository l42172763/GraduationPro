﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AllStatics
{
    public static bool TestMode = false;//测试模式
    public static bool AutoNavingNow = false;//角色是否正在进行自动寻路
    public static bool NeedShowIntroduce = false;//是否显示场景介绍
    public static int ScenesNumber;
    public static string CurrentUser;
    public static List<string> DefaultClassesInfo = new List<string>
    {
        "高等数学",//课程1
        "1",
        "1",
        "1",
        "指相对于初等数学而言，数学的对象及方法较为繁杂的一部分。广义地说，初等数学之外的数学都是高等数学，也有将中学较深入的代数、几何以及简单的集合论初步、逻辑初步称为中等数学的，将其作为中小学阶段的初等数学与大学阶段的高等数学的过渡。通常认为，高等数学是由微积分学，较深入的代数学、几何学以及它们之间的交叉内容所形成的一门基础学科。主要内容包括：数列、极限、微积分、空间解析几何与线性代数、级数、常微分方程。工科、理科、财经类研究生考试的基础科目。",
        "高等数学2",
        "高等数学2",//课程2
        "2",
        "1",
        "1",
        "一般认为，16世纪以前发展起来的各个数学学科总的是属于初等数学的范畴，因而，17世纪以后建立的数学学科基本上都是高等数学的内容。由此可见，高等数学的范畴无法用简单的几句话或列举其所含分支学科来说明。",
        null,
        "Java程序设计",//课程3
        "101",
         "2",
         "2",
        "E:\\Java面向对象程序设计.pdf",
        "Java实验",
        "Java实验",//课程4
        "102",
        "2",
        "2","E:\\JAVA面向对....pdf",
        null,
        "人工智能导论",//课程5
        "201",
        "3",
        "2",
        "https://www.icourse163.org/course/ZJUT-1002694018",
        null
    };
}
