# Unity 项目使用 GitHub Desktop 的版本控制

---

## 🧰 一、GitHub Desktop 基本使用流程

1. **初始化项目**
   - 在 GitHub Desktop 创建本地仓库（或克隆远程仓库）
   - 选择 Unity 项目根目录作为仓库路径（含 `Assets/`, `ProjectSettings/`）

2. **配置 .gitignore**

   - 可使用 Unity 官方推荐 `.gitignore` 模板：https://github.com/github/gitignore/blob/main/Unity.gitignore

3. **提交更改**
   - 在 GitHub Desktop 中查看变更（Uncommitted changes）
   - 填写 Commit Message 并点击 "Commit to `branch-name`"
   - 点击 "Push origin" 将变更同步到远程仓库

4. **分支管理**
   - 点击左上角分支下拉，创建并切换分支（如：`animator`, `feature-X` 等）
   - 每个功能点建议独立分支，开发完成后合并回主分支（main/dev）

---

## ⚠️ 二、使用注意事项

### 1. **使用 Unity 编辑器进行所有资源移动、重命名等操作**
- 避免手动在系统文件夹中移动 `.png`, `.prefab`, `.unity` 文件。
- Unity 会自动处理 `.meta` 文件，保持 GUID 不变，避免资源引用丢失。

### 2. **避免多人或多个分支同时修改同一个 `.unity` 场景文件**
- 场景文件是 YAML 格式，结构复杂，容易产生 Git 冲突。
- 尽量使用：
  - **Prefab 拆分**
  - **场景分离（Additive Scene）**
  - **功能模块独立开发再整合**

### 3. **切换分支时必须关闭 Unity 编辑器**
| 情况 | 是否关闭 Unity |
|------|----------------|
| 切换分支（checkout） | ✅ 必须关闭 |
| 回退版本 | ✅ 必须关闭 |
| 合并分支 | ✅ 必须关闭 |
| 修改代码（.cs 文件） | ⛔ 可不关闭 |

> 原因：Unity 会锁定和监听项目文件，可能与 Git 操作冲突，导致资源状态混乱。

### 4. **提交前，确保所有更改已经保存**
- 场景已保存（Ctrl+S）；
- Prefab 变更已 Apply；
- 避免提交未完成状态。

### 5. **优先将 GameObject 模块化为 Prefab**
- 方便跨场景、跨分支复用；
- 合并时冲突概率低；
- 支持“拖入主场景”的轻量整合方式。

### 6. 多分支下的版本控制——场景部分
- Unity对场景的存储是用一个.unity文件进行的，场景文件时一个YAML格式的文件，在不同分支合并时，git并不能识别YAML与场景的联系，所以需要逐行处理冲突，相当麻烦。
- 一个方法是，在新建分支进行模块开发时，同时基于主分支场景，复制一个副本，并改名为相应的模块名，例如主场景为main.unity。制作动画小模块，可以分成animator.unity。
- 子分支在这个新的场景文件中进行编辑，修改，这样在合并时不会影响到主场景。这种方法要多将分支中编辑的内容进行模块化，多设置为【prefab】。
- 合并的时候，因为两个场景文件彼此是不冲突的，所以合并时没有冲突，合并的方法是：
1. 采用分支中创建的各种prefab，在主场景中进行摆放
2. 尝试在主场景中读取其他的场景文件。

---

### 📁 分支并存：使用 `git worktree`（推荐）

```bash
# 在项目外创建 animator 分支对应的副本
git worktree add ../MyProject_animator animator
