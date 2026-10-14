import React from 'react';
const fmt=d=>new Date(d).toLocaleString('vi-VN');
export default function ReportList({data,onDetail,onPage}) {
  return <section className="panel" id="report-list"><div className="section-title"><div><h2>US-02 · Danh sách đồ thất lạc</h2><p>{data.total} bài đăng đang mở</p></div><span className="micro">Sắp xếp: mới nhất</span></div>
    <div className="cards">{data.items.map(r=><article className="report-card" key={r.id}>
      <div className="card-head"><span className={'type '+r.type.toLowerCase()}>{r.type==='LOST'?'BÁO MẤT':'NHẶT ĐƯỢC'}</span><span className="micro">{fmt(r.createdAt)}</span></div>
      <h3>{r.itemName}</h3><p>{r.description.length>125?r.description.slice(0,125)+'…':r.description}</p>
      <div className="meta"><span>📁 {r.category}</span><span>📍 {r.location}</span></div>
      <button className="light" onClick={()=>onDetail(r.id)}>Xem chi tiết →</button>
    </article>)}</div>
    {data.items.length===0&&<div className="empty">Không tìm thấy bài đăng phù hợp. Hãy thử từ khóa hoặc bộ lọc khác.</div>}
    {data.total>data.pageSize&&<div className="pager"><button className="light" disabled={data.page===1} onClick={()=>onPage(data.page-1)}>← Trước</button><span>Trang {data.page}/{Math.ceil(data.total/data.pageSize)}</span><button className="light" disabled={data.page*data.pageSize>=data.total} onClick={()=>onPage(data.page+1)}>Sau →</button></div>}
  </section>
}
