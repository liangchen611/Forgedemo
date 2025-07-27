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

### 🛑 Unity 编辑器操作注意事项

| 操作 | 建议 |
|------|------|
| 切换分支（checkout） | **关闭 Unity 编辑器后操作** |
| 回退版本（reset/revert） | **关闭 Unity 编辑器后操作** |
| 合并分支（merge） | **关闭 Unity，避免资源错乱** |
| 编辑脚本文件（*.cs） | 可在 Unity 打开状态下直接修改并提交 |

---

### 💾 保存和资源一致性

- 每次切换分支前：
  - **保存所有场景与 Prefab 修改**
  - 退出 Animator、Timeline、Play 模式等状态
  - 若有未提交修改，请先 Commit 或使用 Stash

- 切换分支后：
  - 删除 `Library/` 目录（可选，用于强制资源重导入）
  - 使用 Unity 的 **Assets → Reimport All** 修复潜在错误

---

### 📁 分支并存：使用 `git worktree`（推荐）

```bash
# 在项目外创建 animator 分支对应的副本
git worktree add ../MyProject_animator animator
