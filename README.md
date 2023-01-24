# 개발계획  
# Title: My House Is Fantastic  

장르: 3인칭 TPS게임.
재미 요소: 축소, 소셜/액션/격투/초능력아이템/생존/경쟁/술래잡기/가구배치커스텀/레이드  

## 게임 배경 스토리.  

'방에서 시작하는 플레이어. 정상적인 크기로 방을 돌아다닐 수 있다. 가구를 만져 적당한 상호작용도 가능하다.  
 카운트바가 줄어들고, 다 줄어들면 플레이어는 작아진 채로 랜덤 위치에 스폰된다. 플레이어가 선택한 캐릭터마다 고유의 액션과 피지컬을 가지고 있다.  

## 수익화  

인앱결재: 와드 스킨 구매. 커스텀 가구 에셋 구매. 대기실 아바타 커스텀 구매. 캐릭터 구매(전부 게임머니만으로도 살 수 있으나 더 빨리 가지고 싶은 사람들 대상)  
광고: 3시간에 1번씩만 대기실 입장할 때 30초 광고. 3시간에 1번씩만 무료 게임머니 지급 스킵가능 광고.  

## 게임 요소 개발 순서.

### 재미 요소 추가 순서.
축소(필수) -> 술래잡기모드 -> 액션/격투모드 -> 소셜/비전투모드 -> 가구배치커스텀기능 -> 레이드모드

# 후속작 계획.  
VR버전.   

# 개발 일지  
[20230120] 배경 에셋 가구 애니메이션  
[20230123] House에셋 카테고리 정리, InteractRaycast 레이어 변경 (Layer8 -> Layer7), 프리팹 수정, Video/gif 업로드  
[20230123-2] Keyboard Input매니저, define 작성, forward 테스트, Video/gif 업로드  
[20230124] Keyboard Move, jump작성. GroundController작성, 컨트롤러에서 TerrainCollider.material, CapsuleCollider.material 생성, 추가.  
[20230125] (InputManager.cs) Keyboard WASD 방향키는 호환성을 위해 Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") 메소드를 사용.  점프키는 그대로 (Define.cs)에서 정의한 enum을 참조함.  (PlayerController.cs)에서 AddForce로 점프 구현, position으로 이동 구현함. InputManager에서 만든 xzInput벡터를 불러와서 이동할 방향벡터로 참조.  


