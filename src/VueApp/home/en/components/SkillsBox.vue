﻿<template>
    <div class="box has-text-centered">
        <span class="is-size-2" role="img" aria-label="emoji">👨‍💻</span>
        <div class="columns is-centered">
            <div class="column is-four-fifths">
                <div class="field gap-top">
                    <span class="is-size-5">Languages</span>
                </div>
                <div class="field">
                    <div class="tags is-centered">
                        <span class="tag is-float-text">C#</span><span class="tag is-float-text">C/C++</span><span class="tag is-float-text">SQL</span><span class="tag is-float-text">JavaScript</span><span class="tag is-float-text">TypeScript</span><span class="tag is-float-text">Scss</span>
                    </div>
                </div>
                <div class="field gap-top">
                    <span class="is-size-5">Databases</span>
                </div>
                <div class="field">
                    <div class="tags is-centered">
                        <span class="tag is-float-text">MySQL</span><span class="tag is-float-text">SQL Server</span><span class="tag is-float-text">Redis</span><span class="tag is-float-text">Elasticsearch</span><span class="tag is-float-text">InfluxDB</span><span class="tag is-float-text">AnalyticDB</span>
                    </div>
                </div>
                <div class="field gap-top">
                    <span class="is-size-5">Frameworks</span>
                </div>
                <div class="field">
                    <div class="tags is-centered">
                        <span class="tag is-float-text">ASP.NET</span><span class="tag is-float-text">WPF</span><span class="tag is-float-text">Vue</span><span class="tag is-float-text">Element</span><span class="tag is-float-text">Bulma</span>
                    </div>
                </div>
                <span class="gap-top"></span>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'

@Component({
    name: 'SkillsBox'
})
export default class SkillsBox extends Vue { }
</script>

<style scoped lang="scss">
</style>
