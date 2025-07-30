## Notes-Animation1
---
# 1.如何复制资产

***选中资产后，使用ctrl+D，同时复制一个资产副本***，与此同时，还会再生成一个meta文件用来记录当前文件的位置信息。

***最好不要在文件管理器中进行复制，而是直接在编辑器IDE当中复制，减少meta出错的可能性。***

---
## 2.动画器基本应用：
通过行为状态树来完成动画的转变，创建若干个状态以及其转换逻辑transition，引入外部参数作为状态转换的依据，同时可以在脚本中，通过setfloat，setbool等方式改变动画器的参数。

- ### layer mask
- ### blend tree
- ### root motion
- ### transition optimize(offset, exit, duration)
- ### animator override


## 3.PIXEL PER UNIT(PPU)
sprite的像素大小与视觉大小(16×16)
容易发生tile的sprtie与tilemap pallete大小不一致的情况，所以务必进行调整

---
## 4.项目文件结构管理
unity在进行各个模块都容易产生大量的资产，因此对资产进行模块化统一化的管理非常重要
将arts-视觉资源，scripts-脚本，tileset-与tilemap有关的设置放在此处

---
## 5.sprite editor
使用slice对sprite类型的素材进行拆分分割

---
## 6.可能会导致tilemap碰撞盒与player碰撞盒出现差异的原因：

 🔍 1.Tilemap 的位置未对齐整数单位（0,0）

 🔍 2.Tile 的 Sprite 本身“带透明边”


 🔍 3.Tile Collider 没设置好（未勾选 Composite）

如果你给 Tilemap 加了 Tilemap Collider 2D，请务必配合 Composite Collider 2D 否则会出现“浮空”或“穿透”现象


🔍 4. 角色的 Collider 设置过小或锚点偏移


🔍 5. Pixels Per Unit (PPU) 不一致导致视觉错位

---
## 7.tilemap-grid的碰撞检测（合并tilemap中的砖块）
对于tilemap中的grid网格，如果不加入画布中的方块，那么相应的格不会产生碰撞，而加入画布中的色块后，会根据色块的像素大小（而非grid的网格大小）产生碰撞盒

不同的色块之间可以选择其碰撞盒的组成关系————使用composite collisionbox，或者，在tilemap collision中指定composite operation

---
## 8.跟随相机和主相机的设置
跟随相机：使用cinemachine，对2D场景来说，需要跟随某个目标的情况下，可以选用target camera-2D camera。

创建cinemachine后，主相机会自动增加cinemachine brain用以控制cinemachine的运作，该组件需要激活，否则cinemachine不会生效。

## **对2D项目来说，主相机使用正交投影orthographic结果会比较好（如果采用2D cinemachine来限制跟随相机的移动范围，并增加了2D confiner的情况下，如果主相机的projection为perspective透视投影，会导致跟随相机无法移动的情况）**
究其原因，是采用透视投影的情况下，cinemachine的投影盒是呈现出透视投影中心的X状发散分布，会直接与cinemachine上的confiner发生碰撞，导致cinemachine无法移动；如果采用的是正交投影，则cinamachine会是一个盒子，不会直接与confiner发生碰撞，可以正常移动

---
### 9.parallex background-视差滚动背景
近处贴图移动较快，远处的景色，如山、天空等的贴图，移动相对较慢