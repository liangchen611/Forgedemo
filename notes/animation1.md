## Notes-Animation1
---
# 1.如何复制资产

***选中资产后，使用ctrl+D，同时复制一个资产副本***，与此同时，还会再生成一个meta文件用来记录当前文件的位置信息。

***最好不要在文件管理器中进行复制，而是直接在编辑器IDE当中复制，减少meta出错的可能性。***

---
### 2.动画器基本应用：
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
### 6.可能会导致tilemap碰撞盒与player碰撞盒出现差异的原因：

 🔍 1.Tilemap 的位置未对齐整数单位（0,0）

 🔍 2.Tile 的 Sprite 本身“带透明边”


 🔍 3.Tile Collider 没设置好（未勾选 Composite）

如果你给 Tilemap 加了 Tilemap Collider 2D，请务必配合 Composite Collider 2D 否则会出现“浮空”或“穿透”现象


🔍 4. 角色的 Collider 设置过小或锚点偏移


🔍 5. Pixels Per Unit (PPU) 不一致导致视觉错位

---
### 7.tilemap-grid的碰撞检测（合并tilemap中的砖块）
对于tilemap中的grid网格，如果不加入画布中的方块，那么相应的格不会产生碰撞，而加入画布中的色块后，会根据色块的像素大小（而非grid的网格大小）产生碰撞盒

不同的色块之间可以选择其碰撞盒的组成关系————使用composite collisionbox，或者，在tilemap collision中指定composite operation
