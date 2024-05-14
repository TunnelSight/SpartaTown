필수과제 5번까지는 완성해서 필수과제 6,7번을 구현하려다가 실패했습니다.

MainScene과 SelectScene이 있는데 처음에 SelectScene에서
캐릭터를 하나 선택하고 이름을 적고 결정 버튼을 누르면 MainScene으로 넘어갑니다.
씬을 넘어간 직후에 선택한 캐릭터에 따라 CharMaker.instance.selectedNum(1 혹은2)값에 따라서 캐릭터 프리팹을 Instantiate하려고 했습니다.

캐릭터를 조작해서 이동하는 방법과 맵을 만드는 건 구현했는데, 씬을 넘어가서 캐릭터를 Instantiate하는 걸 실패했습니다.