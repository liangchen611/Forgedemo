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
