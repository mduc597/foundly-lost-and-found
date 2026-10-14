import React from 'react';
const fmt=d=>new Date(d).toLocaleString('vi-VN');
export default function ReportDetail({report,user,onClose,onEdit,onDelete}) {
  return <div className="overlay" role="presentation" onMouseDown={e=>{if(e.target===e.currentTarget)onClose()}}>
    <section className="detail panel" role="dialog" aria-modal="true" aria-label="Chi tiết bài đăng">
      <div className="section-title"><span className={'type '+report.type.toLowerCase()}>{report.type==='LOST'?'BÁO MẤT':'NHẶT ĐƯỢC'}</span><button className="light" onClick={onClose}>✕ Đóng</button></div>
      <h2>{report.itemName}</h2><p>{report.description}</p>
      <dl className="details"><div><dt>Danh mục</dt><dd>{report.category}</dd></div><div><dt>Khu vực</dt><dd>{report.location}</dd></div><div><dt>Thời gian mất/nhặt</dt><dd>{fmt(report.eventTime)}</dd></div><div><dt>Ngày đăng</dt><dd>{fmt(report.createdAt)}</dd></div><div><dt>Trạng thái</dt><dd>{report.status==='OPEN'?'Đang hiển thị':report.status}</dd></div><div><dt>Người đăng</dt><dd>{report.reporter||'Sinh viên'}</dd></div></dl>
      {user?.id===report.userId&&<div className="form-bottom"><button className="light" onClick={()=>onEdit(report)}>Sửa bài</button><button className="danger" onClick={()=>onDelete(report)}>Xóa bài</button></div>}
      <p className="hint">Sprint 1 chỉ bao gồm thông tin bài đăng; Matching, chat, yêu cầu nhận đồ thuộc Sprint sau.</p>
    </section>
  </div>;
}
