document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('current-year').textContent = new Date().getFullYear();

    fetchPersonalInfo();
    fetchExperience();
    fetchSkills();
    fetchEducation();
});

function formatDate(dateString) {
    if (!dateString) return 'Present';
    const options = { year: 'numeric', month: 'long' };
    return new Date(dateString).toLocaleDateString('en-US', options);
}

async function fetchPersonalInfo() {
    try {
        const response = await fetch('/api/PersonalInfo');
        const data = await response.json();
        
        document.getElementById('personal-loader').classList.add('hidden');
        
        if (data.isSuccess && data.value) {
            const info = data.value;
            
            document.getElementById('personal-content').classList.remove('hidden');
            
            document.getElementById('pi-name').textContent = info.fullName;
            document.getElementById('pi-jobtitle').textContent = info.jobTitle;
            
            if (info.summary) {
                document.getElementById('pi-summary').textContent = info.summary;
            } else {
                document.getElementById('pi-summary').style.display = 'none';
            }
            
            document.querySelector('#pi-email span').textContent = info.email;
            
            if (info.phone) {
                document.querySelector('#pi-phone span').textContent = info.phone;
            } else {
                document.getElementById('pi-phone').style.display = 'none';
            }
            
            if (info.city || info.country) {
                document.getElementById('pi-city').textContent = info.city || '';
                document.getElementById('pi-country').textContent = info.country || '';
            } else {
                document.getElementById('pi-location').style.display = 'none';
            }
            
            if (info.photoUrl) {
                document.getElementById('pi-photo').src = info.photoUrl;
            } else {
                document.getElementById('pi-photo').src = `https://ui-avatars.com/api/?name=${encodeURIComponent(info.fullName)}&background=f1f5f9&color=0f172a&size=250`;
            }

            if (info.gitHubUrl) {
                const btn = document.getElementById('pi-github');
                btn.href = info.gitHubUrl;
                btn.classList.remove('hidden');
            }
            
            if (info.linkedInUrl) {
                const btn = document.getElementById('pi-linkedin');
                btn.href = info.linkedInUrl;
                btn.classList.remove('hidden');
            }
            
            if (info.cvUrl) {
                const btn = document.getElementById('pi-cv');
                btn.href = info.cvUrl;
                btn.classList.remove('hidden');
            }
        }
    } catch (error) {
        console.error('Error fetching personal info:', error);
        document.getElementById('personal-loader').classList.add('hidden');
    }
}

async function fetchExperience() {
    try {
        const response = await fetch('/api/Experience');
        const data = await response.json();
        
        document.getElementById('exp-loader').classList.add('hidden');
        
        if (data.isSuccess && data.value && data.value.length > 0) {
            const list = document.getElementById('experience-list');
            
            const experiences = data.value.sort((a, b) => new Date(b.startDate) - new Date(a.startDate));
            
            experiences.forEach(exp => {
                const start = formatDate(exp.startDate);
                const end = formatDate(exp.endDate);
                
                let highlightsHtml = '';
                if (exp.highlights && exp.highlights.length > 0) {
                    highlightsHtml = `<ul class="highlights-list">
                        ${exp.highlights.map(h => `<li>${h}</li>`).join('')}
                    </ul>`;
                }

                const item = document.createElement('div');
                item.className = 'timeline-card';
                item.innerHTML = `
                    <div class="timeline-date-box">
                        ${start} <br>to<br> ${end}
                    </div>
                    <div class="timeline-content-box">
                        <h3>${exp.position}</h3>
                        <h4>${exp.companyName} ${exp.address ? `• ${exp.address}` : ''}</h4>
                        ${highlightsHtml}
                    </div>
                `;
                list.appendChild(item);
            });
        } else {
            document.getElementById('experience-list').innerHTML = '<p class="text-muted">No experience entries found.</p>';
        }
    } catch (error) {
        console.error('Error fetching experience:', error);
        document.getElementById('exp-loader').classList.add('hidden');
    }
}

function getStarsHtml(level) {
    // Determine the rating from 1 to 5 based on what was saved in the DB.
    // If user input values like 1,2,3,4,5 in the DB, use it directly.
    // If user input values like 20,40,60,80,100, divide by 20.
    let score = level;
    if (level > 5) {
        score = Math.round(level / 20);
    }
    
    // Fallback to 1 if something is weird
    if (score < 1) score = 1;
    if (score > 5) score = 5;

    let stars = '';
    for (let i = 1; i <= 5; i++) {
        if (i <= score) {
            stars += '<i class="fas fa-star active"></i>';
        } else {
            stars += '<i class="fas fa-star"></i>';
        }
    }
    return stars;
}

async function fetchSkills() {
    try {
        const response = await fetch('/api/Skill');
        const data = await response.json();
        
        document.getElementById('skills-loader').classList.add('hidden');
        
        if (data.isSuccess && data.value && data.value.length > 0) {
            const list = document.getElementById('skills-list');
            
            data.value.forEach(skill => {
                const item = document.createElement('div');
                item.className = 'skill-box';
                item.innerHTML = `
                    <span class="name">${skill.name}</span>
                    <div class="stars">
                        ${getStarsHtml(skill.level)}
                    </div>
                `;
                list.appendChild(item);
            });
        } else {
            document.getElementById('skills-list').innerHTML = '<p class="text-muted">No skills found.</p>';
        }
    } catch (error) {
        console.error('Error fetching skills:', error);
        document.getElementById('skills-loader').classList.add('hidden');
    }
}

async function fetchEducation() {
    try {
        const response = await fetch('/api/Education');
        const data = await response.json();
        
        document.getElementById('edu-loader').classList.add('hidden');
        
        if (data.isSuccess && data.value) {
            const edu = data.value;
            const list = document.getElementById('education-list');
            
            const start = formatDate(edu.startDate);
            const end = formatDate(edu.endDate);
            
            const item = document.createElement('div');
            item.className = 'timeline-card';
            item.innerHTML = `
                <div class="timeline-date-box">
                    ${start} <br>to<br> ${end}
                </div>
                <div class="timeline-content-box">
                    <h3>${edu.degree} ${edu.fieldOfStudy ? `in ${edu.fieldOfStudy}` : ''}</h3>
                    <h4>${edu.institution}</h4>
                    ${edu.grade ? `<p><strong>Grade:</strong> ${edu.grade}</p>` : ''}
                    ${edu.description ? `<p>${edu.description}</p>` : ''}
                </div>
            `;
            list.appendChild(item);
        } else {
             document.getElementById('education-list').innerHTML = '<p class="text-muted">No education details found.</p>';
        }
    } catch (error) {
        console.error('Error fetching education:', error);
        document.getElementById('edu-loader').classList.add('hidden');
    }
}
