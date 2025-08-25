let tasks = [];

function loadTasks() {
  const stored = localStorage.getItem('tasks');
  tasks = stored ? JSON.parse(stored) : [];
}

function saveTasks() {
  localStorage.setItem('tasks', JSON.stringify(tasks));
}

function renderTasks() {
  const tbody = document.querySelector('#taskTable tbody');
  tbody.innerHTML = '';
  tasks.forEach((t, i) => {
    const tr = document.createElement('tr');
    tr.innerHTML = `
      <td>${t.name}</td>
      <td>${t.priority}</td>
      <td>${t.status}</td>
      <td>${t.due || ''}</td>
      <td>
        <button class="btn btn-sm btn-outline-primary me-1" data-index="${i}" data-action="edit">Editar</button>
        <button class="btn btn-sm btn-outline-danger" data-index="${i}" data-action="delete">Eliminar</button>
      </td>`;
    tbody.appendChild(tr);
  });
}

function addTask() {
  const name = document.getElementById('taskName').value.trim();
  const priority = document.getElementById('taskPriority').value;
  const status = document.getElementById('taskStatus').value;
  const due = document.getElementById('taskDue').value;
  if (!name) return;
  tasks.push({ name, priority, status, due });
  saveTasks();
  renderTasks();
  document.getElementById('taskName').value = '';
  document.getElementById('taskDue').value = '';
}

function handleTableClick(e) {
  if (!e.target.dataset.action) return;
  const idx = e.target.dataset.index;
  const task = tasks[idx];
  if (e.target.dataset.action === 'delete') {
    tasks.splice(idx, 1);
  } else if (e.target.dataset.action === 'edit') {
    const name = prompt('Tarea', task.name);
    if (name === null) return;
    const priority = prompt('Prioridad (Alta, Media, Baja)', task.priority);
    if (priority === null) return;
    const status = prompt('Estado (Por hacer, En progreso, Completada)', task.status);
    if (status === null) return;
    const due = prompt('Fecha límite (YYYY-MM-DD)', task.due);
    tasks[idx] = { name, priority, status, due };
  }
  saveTasks();
  renderTasks();
}

function exportCsv() {
  const headers = ['Tarea', 'Prioridad', 'Estado', 'Fecha limite'];
  const rows = tasks.map(t => [t.name, t.priority, t.status, t.due]);
  const csvContent = [headers, ...rows].map(r => r.map(v => `"${v || ''}"`).join(',')).join('\n');
  const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
  const url = URL.createObjectURL(blob);
  const a = document.createElement('a');
  a.href = url;
  a.download = 'tasks.csv';
  a.click();
  URL.revokeObjectURL(url);
}

function importJson(file) {
  const reader = new FileReader();
  reader.onload = e => {
    try {
      const imported = JSON.parse(e.target.result);
      if (Array.isArray(imported)) {
        tasks = tasks.concat(imported);
        saveTasks();
        renderTasks();
      }
    } catch (err) {
      alert('Archivo JSON inválido');
    }
  };
  reader.readAsText(file);
}

document.getElementById('addTaskBtn').addEventListener('click', addTask);
document.getElementById('taskTable').addEventListener('click', handleTableClick);
document.getElementById('exportCsvBtn').addEventListener('click', exportCsv);
document.getElementById('importJsonInput').addEventListener('change', e => {
  const file = e.target.files[0];
  if (file) importJson(file);
  e.target.value = '';
});

loadTasks();
renderTasks();
