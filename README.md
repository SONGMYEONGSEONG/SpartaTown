# SpartaTown
SCC_Unity6기_과제_SpartaTown

### [프로젝트 소개]
SpartaTown
유니티2D 훈련 과정으로 구조 및 고급 문법 사용을 익히기 위한 개인과제 프로젝트

개발환경 - Unity2D, C#, Visual Studio

---
### [프로젝트 목표]
- 필수 기능과 도전 기능을 전부 구현하기
- 강의에서 들은 구조를 최대한 활용해서 설계하기

---
### [개발 기간]
2024.10.10 - 2024.10.13 (3일)

---
### [Funtion]
#### 1.캐릭터 생성 - 이름 입력, 캐릭터 선택
![1](https://github.com/user-attachments/assets/b205d75c-34a7-4889-bca0-37200ced24e2)   
![3](https://github.com/user-attachments/assets/4a78948d-fc1d-4670-af63-9a9b260e2e56)   
▲ 캐릭터 선택과 이름 입력을 한 화면

게임을 시작할때 등장하는 화면으로 사용할 캐릭터 선택과 이름을 입력 할 수 있습니다.   
캐릭터 선택을 하지 않을시 펭귄 캐릭터로 게임이 시작됩니다.   
이름은 2 ~ 10 글자 범위 내가 아닌경우 게임시작 버튼이 눌리지 않습니다.   

---
#### 2. 캐릭터 이동, 카메라 따라가기
![1](https://github.com/user-attachments/assets/b986c40c-5993-4239-aa6b-f6cda1fa53e2)

이동은 WASD로 캐릭터 이동을 할 수 있습니다.   
캐릭터의 바라보는 방향은 마우스 위치 방향을 향합니다.   

카메라는 Cinemachine 컴포넌트를 사용하여 구성하였습니다.   

---
#### 3. 방 만들기 
![image](https://github.com/user-attachments/assets/4a7f87d4-894c-40de-ac1e-400c87319687)
![image](https://github.com/user-attachments/assets/7e9846b0-703c-4c33-a5eb-0870bcf41b05)

타일 맵 기능으로 방을 만들었으며 , 오브젝트를 레이어 처럼 사용하여 구성 하였습니다.   

---
#### 4. 인게임 이름 바꾸기 , 참석인원 UI
![2](https://github.com/user-attachments/assets/a326fe88-ea64-4b8f-bd83-c0741ae62925)

인게임 화면에서 ESC를 누르면 Menu 바가 나타나며 마우스 클릭으로 해당 팝업을 사용 할 수 있습니다.   
이름 변경시 참석인원 UI에 바로 변경되어 표시됩니다.   

---
#### 5. 인게임 캐릭터 선택
![3](https://github.com/user-attachments/assets/958983e4-569f-4fcc-96cd-1ff60fad9450)

캐릭터 변경 버튼을 누르면 캐릭터 변경 팝업창이 뜨고 원하는 캐릭을 누르고 변경을 누르면 인게임 캐릭터가 변경 됩니다.      

---
#### 6. NPC 대화
![5](https://github.com/user-attachments/assets/32b78b11-a9ef-4fcd-9614-a78cf35417ea)

상호작용이 가능한 객체에 접근시 12시 방향에 알람 팝업창이 뜹니다.   
F를 눌러 상호작용이 가능하고 대화 중에 F를 눌러 다음 대사를 볼 수 있고   
마지막 대사인경우 팝업창이 꺼집니다.   

---
