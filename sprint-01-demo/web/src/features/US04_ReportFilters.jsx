import React from 'react';
export default function ReportFilters({catalog,filters,onChange,onClear}) {
  const update=(key,value)=>onChange({...filters,[key]:value});
  return <section className="filters panel"><div className="section-title"><h2>US-04 · Bộ lọc</h2><button className="light" onClick={onClear}>Đặt lại</button></div>
    <div className="filtergrid">
      <label>Loại bài<select value={filters.type} onChange={e=>update('type',e.target.value)}><option value="">Tất cả</option><option value="LOST">Mất đồ</option><option value="FOUND">Nhặt được</option></select></label>
      <label>Danh mục<select value={filters.categoryId} onChange={e=>update('categoryId',e.target.value)}><option value="">Tất cả</option>{catalog.categories.map(c=><option value={c.id} key={c.id}>{c.name}</option>)}</select></label>
      <label>Khu vực<select value={filters.locationId} onChange={e=>update('locationId',e.target.value)}><option value="">Tất cả</option>{catalog.locations.map(l=><option value={l.id} key={l.id}>{l.name}</option>)}</select></label>
      <label>Đăng từ ngày<input type="date" value={filters.dateFrom} onChange={e=>update('dateFrom',e.target.value)}/></label>
      <label>Đến ngày<input type="date" value={filters.dateTo} min={filters.dateFrom||undefined} onChange={e=>update('dateTo',e.target.value)}/></label>
    </div>
  </section>;
}
